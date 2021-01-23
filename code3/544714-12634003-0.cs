    using(StreamWriter sw = new StreamWriter("C:\[WriteFileName.txt]"))
    {
        StreamReader sr = new StreamReader("C:\[FileName.txt]");
        string line = String.Empty;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("="))
            {
                sw.Write(line));
            }
        }
        sr.Close();
        sw.Close();
    }
