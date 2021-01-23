            List<int> list1 = Enumerable.Range(1, 10000000).ToList();
            List<int> list2 = Enumerable.Range(500000, 10).ToList(); // Gets MUCH slower as 10 increases to 100 or 1000
            Stopwatch sw = Stopwatch.StartNew();
            //list1 = list1.Except(list2).ToList();
            list1.RemoveAll(i => list2.Contains(i));
            sw.Stop();
            var ms1 = sw.ElapsedMilliseconds;
