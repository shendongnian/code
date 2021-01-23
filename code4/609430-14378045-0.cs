    using (StreamWriter jp = new StreamWriter(jobsProcessed, true)) // Appending instead of Overwriting
    {
        jp.WriteLine(DateTime.Now.ToString());
        jp.WriteLine(info);
        jp.WriteLine("------");
    }
