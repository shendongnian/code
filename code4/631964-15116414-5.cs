        class MessageWrapper
        {
            object bMessageLock = new object();
            object pendingBLock = new object();
            int? pendingB;
    
            ManualResetEvent gateOpen = new ManualResetEvent(true); // Gate is open initially.
            
    
            private bool IsGateOpen()
            {
                return gateOpen.WaitOne(0);
            }
    
            private void OpenGate()
            {
                gateOpen.Set();
            }
    
            private void CloseGate()
            {
                gateOpen.Reset();
            }
    
    
            public Message WrapA(int a, int millisecondsTimeout)
            {
                // check if the gate is open. Use WaitOne(0) to return immediately.
                if (IsGateOpen())
                {
                    return new Message(a, null);
                }
                else
                {
                    // This extra lock is to make sure that we don't get stale b's.
                    lock (pendingBLock)
                    {
                        // and reopen the gate.
                        OpenGate();
    
                        // there is a waiting b
                        // Send combined message
                        var message = new Message(a, pendingB);
    
                        pendingB = null;
                        
                        return message;
                    }
                }
            }
    
            public Message WrapB(int b, int millisecondsTimeout)
            {
    
                // Remove this if you don't have overlapping B's
                var timespentInLock = Stopwatch.StartNew();
    
                lock (bMessageLock) // Only one B message can be sent at a time.... may need to fix this.
                {
                    pendingB = b;
    
                    // Close gate
                    CloseGate();
    
                   
                    // Wait for the gate to be opened again (meaning that the message has been sent)
                    if (timespentInLock.ElapsedMilliseconds < millisecondsTimeout && 
                        gateOpen.WaitOne(millisecondsTimeout - timespentInLock.ElapsedMilliseconds)) 
                    // If you don't have overlapping b's use this clause instead.
                    //if (gateOpen.WaitOne(millisecondsTimeout)) 
                    {
                        lock (pendingBLock)
                        {
                            // Gate was opened, so combined message was sent.
                            return null;
                        }
                    }
                    else
                    {
                        // Timeout expired, so send b-only message.
                        lock (pendingBLock)
                        {
                            // reopen gate.
                            OpenGate();
                            pendingB = null;
                            return new Message(null, b);
                        }
                    }
                }
            }
    
          
        }
