    StreamReader sr = new StreamReader(Convert.ToString(openFileDialog1.FileName));
    while (!sr.EndOfStream)
    {
        string l= sr.ReadLine();
        bool nullPresent = l.ToCharArray().Any(x => x.CompareTo('\0') == 0);
        
        if (nullPresent)
        {
            MessageBox.Show("Ignoring line");
        }
        else
        {
            // do other stuff
        }
    }
