            var dictionary = new Dictionary<int, IList<int>>();
            var orderedDictionary = dictionary
                                   .OrderBy(pair => pair.Key)
                                   .ToDictionary(
                                        pair=>pair.Key,
                                        pair=>pair.Value.OrderBy(i=>i));
