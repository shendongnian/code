    public class MyPocoRepository<TMYPOCO>
    {
        private Cache<Criteria, IEnumerable<TMYPOCO>> _cache = new Cache<Criteria, IEnumerable<TMYPOCO>>(CriteriaComparer); // is passed to the dictionary constructor which is actually the cache.
        public IEnumerable<TMYPOCO> GetData(string someParameter, int anotherParameter)
        {
            Criteria criteria = new Criteria();
            criteria.Set("someParameter", someParameter)
                    .Set("anotherParameter", anotherParameter);
            // we can check the cache now based on this...
        } // eo GetData
    } // eo MyPocoRepository<TMYPOCO>
