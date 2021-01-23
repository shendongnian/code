            Dictionary<string, Tuple<string, string>> headCS = new Dictionary<string, Tuple<string, string>>();
            List<string> key  = new List<string>();
            List<string> header = new List<string>();
            List<string> content = new List<string>();
            foreach (KeyValuePair<string, Tuple<string,string>> item in headCS)
            {
                key.Add(item.Key);
                header.Add(item.Value.Item1);
                content.Add(item.Value.Item2);
            }
