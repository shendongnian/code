    public class MessageWrapper
    {
        private readonly object _gate = new object();
        private object _pendingB;
        public void SendA(int a, int millisecondsTimeout, Action<Message> send)
        {
            var b = Interlocked.Exchange<object>(ref _pendingB, null);
            send(new Message(a, (int?)b));
            // this code will just release any pending "assure that B was sent" threads.
            // but everything works fine even without it
            lock (_gate)
            {
                Monitor.PulseAll(_gate);
            }
        }
        public void SendB(int b, int millisecondsTimeout, Action<Message> send)
        {
            // needed for Interlocked to function properly and to be able to chack that exatly this b event was sent.
            var boxedB = (object)(int?)b;
            // excange currently pending B event with newly arrived one
            var enqueuedB = Interlocked.Exchange(ref _pendingB, boxedB);
            if (enqueuedB != null)
            {
                // if there was some pending B event then just send it.
                send(new Message(null, (int?)enqueuedB));
            }
            // now we have to wait up to millisecondsTimeout to ensure that our message B was sent
            lock (_gate)
            {
                // release any currently waiting threads.
                Monitor.PulseAll(_gate);
                
                if (Monitor.Wait(_gate, millisecondsTimeout))
                {
                    // if we there pulsed, then we have nothing to do, as our event was already sent 
                    return;
                }
            }
            // check whether our event is still pending 
            enqueuedB = Interlocked.CompareExchange(ref _pendingB, null, boxedB);
            if (ReferenceEquals(enqueuedB, boxedB))
            {
                // if so, then just send it.
                send(new Message(null, (int?)enqueuedB));
            }
        }
    }
