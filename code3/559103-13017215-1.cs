    // Open the stream and read it back. 
    string s;
    using (StreamReader sr = File.OpenText(filename)) 
    {
        while ((s = sr.ReadLine()) != null) 
        {
            // parse the string and add the values to the list
            string[] parts = s.Split(new [] {','});
            if(parts.Length != 2)
            {
                // throw an exception
            }
            int x, y;
            if (!int.TryParse(parts[0],out x) ||
                !int.TryParse(parts[1],out y))
            {
                // throw an exception
            }
            Klaster klaster = new Klaster();
            klaster.Punkty.Add(new Point(x, y));
            Klastry.Add(klaster);
        }
    }
