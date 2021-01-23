    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Item
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public int Value { get; set; }
        public List<string> Tags { get; set; }
    }
    public class TagsWithCountAndValues : AbstractIndexCreationTask<Item, TagsWithCountAndValues.ReduceResult>
    {
        public class ReduceResult
        {
            public string AccountId { get; set; }
            public string AccountName { get; set; }
            public string Tag { get; set; }
            public int Count { get; set; }
            public int TotalSum { get; set; }
        }
        public TagsWithCountAndValues()
        {
            Map = items => from item in items
                            from tag in item.Tags
                            select new
                            {
                                AccountId = item.AccountId,
                                Tag = tag,
                                Count = 1,
                                TotalSum = item.Value
                            };
            Reduce = results => from result in results
                                group result by result.Tag
                                into g
                                select new
                                {
                                    AccountId = g.Select(x => x.AccountId).FirstOrDefault(),
                                    Tag = g.Key,
                                    Count = g.Sum(x => x.Count),
                                    TotalSum = g.Sum(x => x.TotalSum)
                                };
            TransformResults = (database, results) => from result in results
                                                        let account = database.Load<Account>(result.AccountId)
                                                        select new
                                                        {
                                                            AccountId = result.AccountId,
                                                            AccountName = account.Name,
                                                            Tag = result.Tag,
                                                            Count = result.Count,
                                                            TotalSum = result.TotalSum
                                                        };
        }
    }
