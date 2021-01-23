            var dictionary = new Dictionary<int, IList<int>>();
            var orderedItems = dictionary
                                   .OrderBy(pair => pair.Key)
                                   .Select(new {
                                            Key = pair.Key, 
                                            Value = pair.Value.OrderBy(i => i)});
