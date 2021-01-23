    Stopwatch sw = new Stopwatch();
    sw.Start();
    using (StreamWriter swr = 
             new StreamWriter(File.Open(filePath, FileMode.CreateNew), Encoding.Default, 1000000))
             // change buffer size and Encoding to your needs
    {
        foreach (DataRow dr in dt.Rows)
        {
            swr.WriteLine(string.Join(delimiter, dr.ItemArray));
        }
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
