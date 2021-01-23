            string[] lines = System.IO.File.ReadAllLines("test.txt");
            List<decimal> results = new List<decimal>();
            foreach (var line in lines.Skip(4))
            {
                if (line.StartsWith("<pre>"))
                    break;
                Regex numberReg = new Regex(@"\d+(\.\d){0,1}");
                var result = numberReg.Matches(line).Cast<Match>().FirstOrDefault();
                if (result != null)
                    results.Add(Convert.ToDecimal(result.Value, System.Globalization.CultureInfo.InvariantCulture));
            }
