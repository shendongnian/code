    public class SomeClass
    {
        private readonly ConcurrentQueue<ISocketWriterJob> _writeQueue = new ConcurrentQueue<ISocketWriterJob>();
        private ISocketWriterJob _currentJob;
    
        public void Send(ISocketWriterJob job)
        {
            if (Interlocked.CompareExchange(ref _currentJob, job, null) != null)
            {
                _writeQueue.Enqueue(job);
                return;
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
                _currentJob = null; // maybe some barrier is needed here?...
                if (!_writeQueue.TryDequeue(out _currentJob))
                {
                    return;
                }
            }
    
            _logger.Debug(_writeArgs.GetHashCode() + ": writing more ");
            _currentJob.Write(_writeArgs);
   
            // the job is invoked asycnhronously here.
        }
    }
