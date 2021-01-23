    public class SomeClass
    {
        private readonly Queue<ISocketWriterJob> _writeQueue = new Queue<ISocketWriterJob>();
        private ISocketWriterJob _currentJob;
        private enum State { Idle, Active, Enqueue, Dequeue };
        private State _state;
    
        public void Send(ISocketWriterJob job)
        {
            bool spin = true;
            while(spin)
            {
                switch(_state)
                {
                case State.Idle:
                    if (Interlocked.CompareExchange(ref _state, State.Active, State.Idle) == State.Idle)
                    {
                        spin = false;
                    }
                    // else consider new state
                    break;
                case State.Active:
                    if (Interlocked.CompareExchange(ref _state, State.Enqueue, State.Active) == State.Active)
                    {
                        _writeQueue.Enqueue(job);
                        Interlocked.Exchange(ref _state, State.Active);
                        return;
                    }
                    // else consider new state
                    break;
                case State.Enqueue:
                case State.Dequeue:
                    // spin to wait for new state
                    Thread.Yield();
                    break;
                }
            }
            
            _currentJob.Write(_writeArgs);
    
            // The job is invoked asynchronously here
        }
    
        private void HandleWriteCompleted(SocketError error, int bytesTransferred)
        {
            // error checks etc removed for this sample.
    
            if (_currentJob.WriteCompleted(bytesTransferred))
            {
                _currentJob.Dispose();
                
                bool spin = true;
                while(spin)
                {
                    switch(_state)
                    {
                    case State.Active:
                        if (Interlocked.CompareExchange(ref _state, State.Dequeue, State.Active) == State.Active)
                        {
                            if (!_writeQueue.TryDequeue(out _currentJob))
                            {
                                _currentJob = null;
                                Interlocked.Exchange(_state, State.Idle);
                                return;
                            }
                            else
                            {
                                Interlocked.Exchange(_state, State.Active);
                            }
                        }
                        // else consider new state
                        break;
                        
                    case State.Enqueue:
                    case State.Dequeue:
                        // spin to wait for new state
                        Thread.Yield();
                        break;
                    case State.Idle: // impossible state
                        break;
                    }
                }
            }
    
            _logger.Debug(_writeArgs.GetHashCode() + ": writing more ");
            _currentJob.Write(_writeArgs);
    
            // the job is invoked asycnhronously here.
        }
    }
