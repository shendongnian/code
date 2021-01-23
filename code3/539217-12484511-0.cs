            Dictionary<string, List<int>> storage = new Dictionary<string, List<int>>();
            storage.Add("key1", new List<int>() { 2, 7 });
            storage.Add("key2", new List<int>() { 8, 4, 1});
            storage.Add("key3", new List<int>() { 3, 9, 3 });
            foreach (string key in storage.Keys)
            {
                //access to single storage...
                List<int> subStorage = (List<int>)storage[key];
                foreach (int item in subStorage)
                {
                    //access to single value inside storage...
                }
            }
