            string input = "damage=20 big explosion=50 rangeweapon=50.0";
            string[] parts = input.Split('=');
            Dictionary<string, double> dict = new Dictionary<string, double>();
            for (int i = 0; i < (parts.Length - 1); i++)
            {
                string key = i==0?parts[i]:parts[i].Substring(parts[i].IndexOf(' '));
                string value = i==parts.Length-2?parts[i+1]:parts[i + 1].Substring(0, parts[i + 1].IndexOf(' '));
                dict.Add(key.Trim(), Double.Parse(value));
            }
            foreach (var el in dict)
            {
                Console.WriteLine("Key {0} contains value {1}", el.Key, el.Value);
            }
            Console.ReadLine();
