    using (StreamWriter jp = new StreamWriter(jobsProcessed, true))
    {
        jp.WriteLine(DateTime.Now.ToString());
        jp.WriteLine(info);
        jp.WriteLine("------");
    }
