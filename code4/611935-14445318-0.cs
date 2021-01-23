            var keys = new Dictionary<int, string>();
            keys.Add(1000, "F1");
            keys.Add(1001, "F2");
            keys.Add(1002, "F1");
            keys.Add(1003, "F4");
            keys.Add(1004, "F2");
            var duplicates = keys.GroupBy(i => i.Value).Select(i => new
            {
                keys = i.Select(x => x.Key),
                value = i.Key,
                count = i.Count()
            });
            foreach (var duplicate in duplicates)
            {
                Console.WriteLine("Value: {0} Count: {1}", duplicate.value, duplicate.count);
                foreach (var key in duplicate.keys)
                {
                    Console.WriteLine(" - {0}", key);
                }
            }
