    static long linesinfile(string l)
            {
                long count = 0;
                using (StreamReader r = new StreamReader(l))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)       //counts lines until last line
                    {
                        if (line.StartsWith("#") & line.Length > 1)       //only count lines which start with #
                        {
                            count++;    //increases the count
                        }
                    }
                    return count;       //displays the line count
                }
