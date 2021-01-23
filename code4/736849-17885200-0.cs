     using(StreamReader sr = new StreamReader(PathFile))
     {
        string line = sr.ReadLine();
        while (line != null)
        {
            comboBox1.Items.Add(line);
            line = sr.ReadLine();
        }
     }
