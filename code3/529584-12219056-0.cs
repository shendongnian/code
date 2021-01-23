    string filename = @"c:\zfile";
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int x = 0; x < 300; x++)
    {
        string newfn = filename + x.ToString() + ".txt";
    
        StreamWriter writer = new StreamWriter(newfn);
        writer.Write(text);
        writer.Close();
    }
    sw.Stop();
    long em = sw.ElapsedMilliseconds;
    
    Console.Write(em.ToString());
