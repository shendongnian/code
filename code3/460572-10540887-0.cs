    public class TagsWithCountAndValues : AbstractIndexCreationTask<Item, TagsWithCountAndValues.ReduceResult>
    {
        public class ReduceResult
        {
            public string AccountId { get; set; }
            public string AccountName { get; set; }
            public string TagName { get; set; }
            public int TagCount { get; set; }
            public int TagValue { get; set; }
        }
        public TagsWithCountAndValues()
        {
            Map = items => from item in items
                           from tag in item.Tags
                           select new ReduceResult
                           {
                               AccountId = item.AccountId,
                               TagName = tag,
                               TagCount = 1,
                               TagValue = item.Value
                           };
            Reduce = results => from result in results
                                where result.TagName != null
                                group result by new {result.AccountId, result.TagName}
                                into g
                                select new ReduceResult
                                           {
                                               AccountId = g.Key.AccountId,
                                               TagName = g.Key.TagName,
                                               TagCount = g.Sum(x => x.TagCount),
                                               TagValue = g.Sum(x => x.TagValue),
                                           };
            TransformResults = (database, results) => from result in results
                                                      let account = database.Load<Account>(result.AccountId)
                                                      select new ReduceResult
                                                                 {
                                                                     AccountId = result.AccountId,
                                                                     AccountName = account.Name,
                                                                     TagName = result.TagName,
                                                                     TagCount = result.TagCount,
                                                                     TagValue = result.TagValue,
                                                                 };
        }
    }
