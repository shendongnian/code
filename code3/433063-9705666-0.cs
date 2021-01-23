    public Task<double> GetTask()
    {
        // Return choice of task.
        return new Task<double>(() => 10.0);
    }
