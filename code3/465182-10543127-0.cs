    //...
    List<string> lines = new List<string>();
    using (StreamReader sr = new StreamReader(file))
    {
        while(!sr.EndOfStream)
        {
            lines.Add(sr.ReadLine());
        }
    }
    task1_name.Text = lines[0];
    task1_desc.Text = lines[1];
    //...
