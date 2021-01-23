            using (var sr = new StreamReader(@"d:\Keywords.txt"))
            {
                if (sr.ReadToEnd().ToString().Contains(line) == false)
                {
                    w.WriteLine(line);
                }
            }
