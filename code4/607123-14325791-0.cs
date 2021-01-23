    public class TestIndex : AbstractMultiMapIndexCreationTask<TestIndex.Result>
    {
        public class Result
        {
            public string[] Ids { get; set; }
            public string Name { get; set; }
            public string Tag { get; set; }
        }
        public TestIndex()
        {
            AddMap<EntityA>(entities => from a in entities
                                        from tag in a.Tags
                                        select new
                                            {
                                                Ids = new[] { a.Id },
                                                Name = (string) null,
                                                Tag = tag
                                            });
            AddMap<EntityB>(entities => from b in entities
                                        from tag in b.Tags
                                        select new
                                            {
                                                Ids = new string[0],
                                                b.Name,
                                                Tag = tag
                                            });
            Reduce = results => from result in results
                                group result by result.Tag
                                into g
                                select new
                                    {
                                        Ids = g.SelectMany(x => x.Ids),
                                        g.First(x => x.Name != null).Name,
                                        Tag = g.Key
                                    };
            TransformResults = (database, results) => 
                               results.SelectMany(x => x.Ids)
                                      .Distinct()
                                      .Select(x => database.Load<EntityA>(x));
        }
    }
