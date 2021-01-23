    private object _lock = new object();
    
    public void Error(Object message)
    {
        lock(_lock){
            logger.Error(message);
        }
    }
