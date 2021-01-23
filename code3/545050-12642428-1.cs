    class FileData
    {
    BatchData _batch;
    
    public FileData(BatchData batch)
    {
        this._batch = batch;
    }
    
    private BatchData getbd()
    {
    return _batch;
    }
    
    private void setbd(BatchData bd)
    {
    _batch = bd;
    }
    }
