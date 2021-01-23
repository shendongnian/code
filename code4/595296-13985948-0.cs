    using (var sr = new StreamReader(new FileStream(@"C:\temp\file.csv", FileMode.Open)))
            {
                var line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    // do stuff
                    line = sr.ReadLine();
                }
            }
