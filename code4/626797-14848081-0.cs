            foreach (KeyValuePair<string, List<string>> kvp in dic)
            {
                if (kvp.Key.Contains(";"))
                {
                    var lst = kvp.Value;
                    foreach (string subKey in kvp.Key.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        dic[subKey] = lst;
                    }
                }
            }
