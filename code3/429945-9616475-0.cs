    using (StreamReader sr = new StreamReader(path))
    {
        char[] c = null;
    
        while (sr.Peek() >= 0)
        {
            c = new char[1];
            sr.Read(c, 0, c.Length);
    
            // do something with c[0]
        }
    }
