            var perms = from a in geneticsArray[0]
                        from b in geneticsArray[1]
                        select new string[] { a, b };
            var dict = new Dictionary<string, int>();
            foreach (var ent in perms)
            {
                Array.Sort(ent);
                var _ent = string.Join(",", ent);
                if (dict.ContainsKey(_ent))
                {
                    dict[_ent]++;
                }
                else
                {
                    dict.Add(_ent, 1);
                }
            }
            return dict;
