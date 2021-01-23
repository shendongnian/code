    using(StreamWriter jp = new StreamWriter(jobsProcessed))
    {
        jp.WriteLine(DateTime.Now.ToString());
        jp.WriteLine(info);
        jp.WriteLine("------");
       //jp.Close(); //NO NEED MORE
    }
