            List<string> lst = new List<string>();
            foreach (var key2 in ht.Keys)
            {
                lst.Add(key2.ToString());
            }
            lst.Sort();
            foreach (var item in lst)
            {
                Console.WriteLine(string.Format("{0},{1}", item, ht[item.ToString()]));
            }
