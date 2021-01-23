                var dictionary = new Dictionary<string, int>();
                dictionary.Add("car", 2);
                dictionary.Add("apple", 1);
                dictionary.Add("zebra", 0);
                dictionary.Add("mouse", 5);
                dictionary.Add("year", 3);
                dictionary = dictionary.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
