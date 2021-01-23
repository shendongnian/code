    using (StreamReader sr = new StreamReader(path));
    {
        string contents = sr.ReadToEnd();
       
        if (contents.Contains(//string to check//))
        {
           appendtofile("add string")
        }
    }
