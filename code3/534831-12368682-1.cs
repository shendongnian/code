                    "Board1", "Messages232"
                };
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var s in strings)
            {
                int index = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (Char.IsDigit(s[i]))
                    {
                        index = i;
                        break;
                    }
                }
                dictionary.Add(s.Substring(0, index), int.Parse(s.Substring(index)));
            }
