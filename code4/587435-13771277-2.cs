    public class ServiceCallsByCategory
    {
        public string Category { get; set; }
        public int CategoryCount { get; set; }
        public int[] ServiceCallIds { get; set; }
    }
    public class ServiceCalls_CallsByCategory : AbstractIndexCreationTask<ServiceCall, ServiceCallsByCategory>
    {
        public ServiceCalls_CallsByCategory()
        {
            Map = docs => from doc in docs
                          select new {
                                         Category = doc.Category,
                                         CategoryCount = 1,
                                         ServiceCallIds = new[] { doc.ID },
                                     };
            Reduce = results => from result in results
                                group result by result.Category
                                into g
                                select new {
                                               Category = g.Key,
                                               CategoryCount = g.Sum(x => x.CategoryCount),
                                               ServiceCallIds = g.SelectMany(i => i.ServiceCallIds)
                                           };
        }
    }
