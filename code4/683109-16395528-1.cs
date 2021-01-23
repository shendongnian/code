            string[] lines = System.IO.File.ReadAllLines("test.txt");
            List<double> results = new List<double>();
            foreach (var line in lines.Skip(4))
            {
                if (line.StartsWith("<pre>"))
                    break;
                Regex numberReg = new Regex(@"\d+(\.\d){0,1}");  //will find any number ending in ".X" - it's primitive, and won't work for something like 0.01, but no such data showed up in your example
                var result = numberReg.Matches(line).Cast<Match>().FirstOrDefault();  //use only the first number from each line. You could use Cast<Match>().Skip(1).FirstOrDefault to get the second, and so on...
                if (result != null)
                    results.Add(Convert.ToDouble(result.Value, System.Globalization.CultureInfo.InvariantCulture));  //Note the use of InvariantCulture, otherwise you may need to worry about , or . in your numbers
            }
