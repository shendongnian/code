    public class Cache<T> where T : Cacheable, new()
    {
        private Dictionary<Guid, T> cachedBlocks;
    
        // Constructors and stuff, to mention this is a singleton
    
        public T GetCache(Guid id)
        {
            if (!cachedBlocks.ContainsKey(id))
                cachedBlocks.Add(id, LoadFromSharePoint(id))
            return cachedBlocks[id];
        }
    
        public T LoadFromSharePoint(Guid id)
        {
            return new T { Key = id };    // Here is no more problem.
        }
    }
    public interface Cacheable
    {
        Guid Key { get; set; }
    }
