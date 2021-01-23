    public class CityCodeCount : AbstractIndexCreationTask<Site, CityCodeCount.ReduceResult>
    {
        public class ReduceResult
        {
            public string CityCode { get; set; }
            public int Count { get; set; }
        }
        public CityCodeCount()
        {
            Map = sites => from site in sites
                            select new
                            {
                                site.CityCode,
                                Count = 1
                            };
            Reduce = results => from result in results
                                group result by result.CityCode
                                into g
                                select new
                                {
                                    CityCode = g.Key,
                                    Count = g.Sum(x => x.Count)
                                };
        }
    }
