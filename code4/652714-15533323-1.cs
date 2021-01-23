            Dictionary<string, Tuple<string, string>> headCS = new Dictionary<string, Tuple<string, string>>();
            List<string> key  = new List<string>();
            List<string> header = new List<string>();
            List<string> content = new List<string>();
            foreach (KeyValuePair<string, Tuple<string,string>> item in headCS)
            {
               //print values to console
                Console.WriteLine("{0},{1},{2}", item.Key, item.Value.Item1, item.Value.Item2);
                //store values for in another form just as an example of what they represent
                key.Add(item.Key);
                header.Add(item.Value.Item1);
                content.Add(item.Value.Item2);
            }
