    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("c:\\test.txt", false))
    {
        for (int i = 0; i < lines.Count; i++)
        {
            writer.WriteLine(lines[i]);
        }
    }
        
