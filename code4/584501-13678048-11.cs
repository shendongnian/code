       var values = Regex.Split(element.Value, @"(\.| )");
            foreach (string value in values.Where(x=>!String.IsNullOrWhiteSpace(x)))
            {
                Console.WriteLine(element.Name + " " + value);
            }   
