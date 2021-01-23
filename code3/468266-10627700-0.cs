        using (var text = System.IO.File.ReadAllLines(filename))
        {
            using (var outfile = System.IO.File.CreateText(newfilename))
            {
                foreach (var line in text)
                {
                    if (line.Length > 2)
                        outfile.WriteLine(line.Substring(1, line.Length - 2));
                    else
                        outfile.WriteLine(line);
                }
                outfile.Flush();
            }
        }
