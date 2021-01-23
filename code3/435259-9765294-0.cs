    List<string> collection = new List<string>();
            collection.Add("example sample");
            collection.Add("sample");
            collection.Add("example");
            var varSubstring = collection.Where(x => x.IndexOf("sample")==0).ToList();
            foreach (var vartemp in varSubstring)
            {
            }
