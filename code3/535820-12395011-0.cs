            Dictionary<DateTime, double> dic = new Dictionary<DateTime, double>()
            {
                {DateTime.Now, 111}
            };
            Dictionary<DateTime, double> dic2 = new Dictionary<DateTime, double>()
            {
                {DateTime.Now, 111}
            };
            var list = dic.ToList();
            list.AddRange(dic2.ToList());
            var final = list.Distinct().ToDictionary(x => x.Key, x => x.Value);
