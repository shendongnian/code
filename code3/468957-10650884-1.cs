    private void RunOneAfterAnotherAsync()
    {
        Task task = Task.Factory.StartNew(CreateXMLBW);
        task.ContinueWith(CreateRarBW););
    }
    public void CreateXMLBW()
    {
        // code
    }
    private void CreateRarBW(Task task)
    {
        CreateRarBW();
    }
    public void CreateRarBW()
    {
        // code
    }
