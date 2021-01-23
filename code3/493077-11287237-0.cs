    public class DataRepository : IDataRepository
    {
        public virtual List<Data> GetData()
        {
            //Hit the database and get the data
        }
    }
    public class CachedDataRepository : DataRepository, IDataRepository
    {
        public override List<Data> GetData()
        {
            if(!IsCachedAlready())
            {
                var data = base.GetData();
                AddToCache(data);
            }
            
            return DataFromCache();
        }
    }
