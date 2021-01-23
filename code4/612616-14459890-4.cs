            string[] values = { "1", "2", "3a", "4" };
            int i = int.MinValue;
            var output = (from c in values
                          where int.TryParse(c, out i) 
                          select c).Select(s => int.Parse(s)).ToList();
            foreach (var item in output)
            {
                Console.WriteLine(item.ToString());
            }
