            var result = new List<string[]>();
            using (FileStream fs = new FileStream("", FileMode.Open))
            using (StreamReader rdr = new StreamReader(fs))
            {
                while (!rdr.EndOfStream)
                {
                    result.Add(rdr.ReadLine().Split('|')))
                }
            }
