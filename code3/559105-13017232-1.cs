        void LoadCordinates()
        {
            StreamReader sr = new StreamReader("PATH OF FILE");
            
            Klaster klaster = new Klaster();
            while(sr.EndOfStream == false)
            {
               string temp = sr.ReadLine();
               if(temp.Contains(',') && temp.Split(',').Length == 2)
               {
                   klaster.Punkty.Add(new Point(int.Parse(temp.Split(',')[0].Trim()), int.Parse(temp.Split(',')[0].Trim())));
                   Klastry.Add(klaster);
               }
            }
        }
