    using (StreamReader sr = new StreamReader(infile))
    {
        StreamWriter h = null;
        StreamWriter c = null;
        try
        {
            h = new StreamWriter(...);
            c = new StreamWriter(...);
            string i = "";
            while ((i = sr.ReadLine()) != null)
            {
                // output line here
                // and increment line counter.
                ++line;
                if (line > 2000000)
                {
                    // Close the output files and open new ones
                    h.Close();
                    c.Close();
                    h = new StreamWriter(...);
                    c = new StreamWriter(...);
                    line = 1;
                }
            }
        }
        finally
        {
            if (h != null) h.Close();
            if (c != null) c.Close();
        }
    }
           
