    void load()
    {
        StreamReader sr = new StreamReader("PATH OF FILE");
        
        Klaster klaster = new Klaster();
        while(sr.EndOfStream == false)
        {
           string temp = sr.ReadLine();
            klaster.Punkty.Add(new Point(int.Parse(temp.Split(',')[0].Trim()), int.Parse(temp.Split(',')[0].Trim())));
            Klastry.Add(klaster);
        }
    }
