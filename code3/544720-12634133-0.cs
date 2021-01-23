    using(StreamReader sr = new StreamReader("C:\[FileName.txt]"))
    using(StreamWriter sw = new StreamWriter("C:\[WriteFileName.txt]"))
    {
        string line = String.Empty;
    
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("="))
            {
                sw.Write(line));
            }
        }
    }
