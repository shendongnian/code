            StreamReader reader = new StreamReader(@"F:\BP1.csv");
            List<double> numbers = new List<double>();
            double buffer = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] tokens = line.Split(',');
                foreach (string s in tokens)
                {
                    if (double.TryParse(s, out buffer))
                        numbers.Add(buffer);
                }
            }
            foreach (double d in numbers)
                Console.WriteLine(d.ToString());
            reader.Close();
