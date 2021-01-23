    for(int i = 0; i < tasks.Count; i++)
    {
        double percentage = (double)(i + 1) / (double)tasks.Count;
        Action<double> update = p => 
        {
            progressBar1.Value = (int)Math.Round(p * 100);
        };
        this.Invoke(update, percentage);
        // Do tasks here...
    }
