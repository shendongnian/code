    public class MyIndex : AbstractMultiMapIndexCreationTask<MyIndex.ReduceResult>
    {
        public class ReduceResult
        {
            public string Source { get; set; }
            public string Code { get; set; }
            public string Data { get; set; }
            public int Count { get; set; }
        }
        public MyIndex()
        {
            AddMap<MyDoc>(docs => from doc in docs
                                  select new
                                         {
                                             Source = "Severity",
                                             doc.Severity.Code,
                                             doc.Severity.Data,
                                             Count = 1
                                         });
            AddMap<MyDoc>(docs => from doc in docs
                                  select new
                                         {
                                             Source = "Facility",
                                             doc.Facility.Code,
                                             doc.Facility.Data,
                                             Count = 1
                                         });
            Reduce = results => from result in results
                                group result by new { result.Source, result.Code }
                                into g
                                select new
                                {
                                    g.Key.Source,
                                    g.Key.Code,
                                    g.First().Data,
                                    Count = g.Sum(x => x.Count)
                                };
            TransformResults = (database, results) =>
                               from result in results
                               group result by 0
                               into g
                               select new
                               {
                                   Severity = g.Where(x => x.Source == "Severity")
                                               .ToDictionary(x => x.Data, x => x.Count),
                                   Facility = g.Where(x => x.Source == "Facility")
                                               .ToDictionary(x => x.Data, x => x.Count)
                               };
        }
    }
