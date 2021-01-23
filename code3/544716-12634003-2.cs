    using(StreamWriter sw = new StreamWriter(@"C:\destinationFile.txt"))
    {
        StreamReader sr = new StreamReader(@"C:\sourceFile.txt");
        string line = String.Empty;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("=")) { sw.WriteLine(line)); }
        }
        sr.Close();
    }
