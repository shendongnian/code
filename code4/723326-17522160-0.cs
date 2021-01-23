    void LoadData()
    {
        if (InvokeRequired)
                    Invoke(new MethodInvoker(InnerLoadData));
    }
    void InnerLoadData()
    {
        dt = JobManager.GetTodaysJobs();
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = dt;
    }
