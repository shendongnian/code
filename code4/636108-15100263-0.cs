            Dictionary<int, string> dict = new Dictionary<int, string>();
            Dictionary<int, string> temp = new Dictionary<int, string>();
            dict.Add(123, "");
            dict.Add(124, ""); //and so on
            int[] keys = dict.Keys.ToArray();
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict[keys[i]] == "")
                {
                    temp.Add(keys[i],dict[keys[i]]);
                    dict[keys[i]] = "Moved";
                }
            }
