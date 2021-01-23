    private void btn_StartMeasurement_Click(object sender, EventArgs e)
    {
        Task[] tasks = new Task[]
            {
                Task.Factory.StartNew(funca),
                Task.Factory.StartNew(funcb),
                Task.Factory.StartNew(funcc),
                Task.Factory.StartNew(funcd)
            };
        Task writeTask = Task.Factory.ContinueWhenAll(tasks, (t) => writeToFile());
    }
