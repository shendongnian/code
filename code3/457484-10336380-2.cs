            List<int> demoList = new List<int>() { 1, 2, 1, 1, 1, 3, 2, 1 };
            Dictionary<int,int> keyOrdered = demoList.GroupBy(i => i)
                .Select(i => new { i.Key, Count = i.Count() })
                .OrderBy(i=>i.Key)
                .ToDictionary(i=>i.Key, i=>i.Count);
            var max = keyOrdered.OrderByDescending(i=>i.Value).FirstOrDefault();
           
            List<string> histogram = new List<string>();
            for (int i = max.Value; i >-1 ; i--)
            {
                histogram.Add(string.Concat(keyOrdered.Select(t => t.Value>i?"| ":"  ")));
            }
            histogram.Add(string.Concat(keyOrdered.Keys.OrderBy(i => i).Select(i => i.ToString() + " ")));
            
            histogram.ForEach(i => Console.WriteLine(i));
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Max: {0}, Count:{1}", max.Key, max.Value);
