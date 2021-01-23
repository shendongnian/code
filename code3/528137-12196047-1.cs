    string rawInput = "1 Some Currency Name = 0.4232 Other Currency Name 0.45";
                string[] rawSplit = rawInput.Split('=');
                string firstRate = rawSplit[0].ToString();
                string secondRate = rawSplit[1].ToString();
                string[] lastSplit = secondRate.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
                decimal num = 0;
                lastSplit
                    .Where(d => decimal.TryParse(d, out num))
                    .ToList()
                    .ForEach(i => Console.WriteLine(i));
