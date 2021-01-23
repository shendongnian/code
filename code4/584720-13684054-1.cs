    public void StartConsumingJobs
    {
        _currentJob = _writeQueue.Take();
        // Start job
    }
    private void HandleWriteCompleted(SocketError error, int bytesTransferred)
    {
        // error checks etc removed for this sample.
        if (_currentJob.WriteCompleted(bytesTransferred))
        {
            _currentJob.Dispose();
            _currentJob = _writeQueue.Take();
        }
        _logger.Debug(_writeArgs.GetHashCode() + ": writing more ");
        _currentJob.Write(_writeArgs);
       // Start/continue job?
    }
