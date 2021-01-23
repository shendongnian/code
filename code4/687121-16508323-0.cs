            var nameidlist = new List<NameIDCount>
            {
                new NameIDCount{ID=1,Name="PC", Count =1},
                new NameIDCount{ID=2,Name="PC", Count =1},
                new NameIDCount{ID=3,Name="PC", Count =1},
                new NameIDCount{ID=4,Name="Monitor", Count =1}
            };
            var nl = new List<NameIDCount>();
            nameidlist.GroupBy(x => x.Name, p => p.ID).ToList().ForEach((y) =>
            {
                nl.Add(new NameIDCount { Count = y.ToList().Count, Name = y.Key });
            });
