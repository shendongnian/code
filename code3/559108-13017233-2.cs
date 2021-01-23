    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
    dlg.DefaultExt = ".txt";
    dlg.Filter = "Text document (.txt)|*.txt";
    
    Nullable<bool> result = dlg.ShowDialog();
    
    if (result == true)
    {
        string filename = dlg.FileName;
        _mn.nazwa_pliku.Text = filename;
        
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines) //for everyone line/point
        {
            string[] elements = line.Split(',');
            int x = int.Parse(elements[0]); //get X-value from file
            int y = int.Parse(elements[1]); //get Y-value from file
    
            Klaster klaster = new Klaster();
            klaster.Punkty.Add(new Point(x, y));
            Klastry.Add(klaster);
        }       
    }
