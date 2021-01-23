       ListBox lb = new ListBox();
        System.IO.StreamReader sr = new System.IO.StreamReader("Path to File");
        
        while (!sr.EndOfStream)
        {
            lb.Items.Add(sr.ReadLine());
        }
        
        sr.Close();
