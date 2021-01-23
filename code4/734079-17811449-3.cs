    Stopwatch sw = new Stopwatch();
    Int32 trailerID;
    while (reader.Read())
    {   
        sw.Start();
        trailerId = reader.GetInt(22);
        sw.Stop();
        Debug.WriteLine(trailerId + "-" + sw.ElapsedMilliseconds);//10s - 8s -...
    }
