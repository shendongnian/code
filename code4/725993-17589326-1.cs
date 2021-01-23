            Dictionary<string, int> valuesAndCount = new Dictionary<string, int>();
            foreach (var entry in entries) // entries is a collection of records from table
            {
                string[] values = entry.Split(',');
                foreach (var value in values)
                {
                    if (!valuesAndCount.ContainsKey(value))
                    {
                        valuesAndCount.Add(value, 0);
                    }
                    valuesAndCount[value] = valuesAndCount[value] + 1;
                }
            }
            //Then you'llhave your distinct values and thei count
            foreach (var key in valuesAndCount.Keys)
            {
                Console.WriteLine("{0} {1}",key, valuesAndCount[key]);
            }
