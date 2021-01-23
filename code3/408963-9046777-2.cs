    public class SampleQueryProvider : Dictionary<uint, IEnumerable<IQuery>>, IUserQueryProvider
    {
        public IEnumerable<IQuery> GetQuerysForUser(uint id)
        {
            IEnumerable<IQuery> queries;
            TryGetValue(id, out queries);
            return queries;
        }
    }
