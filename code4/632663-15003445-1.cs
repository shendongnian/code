    public class Cache<T> where T : Cacheable, new()
    {
        private Dictionary<Guid, T> cachedBlocks;
    
        // Constructors and stuff, to mention this is a singleton
    
        public T GetCache(Guid id)
        {
            if (!cachedBlocks.ContainsKey(id))
                cachedBlocks.Add(id, LoadFromSharePoint(id))
            return cachedBlocks[id];
           //you're first checking for presence, and then adding to it
           //which does the same checking again, and then returns the
           //value of key again which will have to see for it again. 
           //Instead if its ok you can directly return
          
           //return cachedBlocks[id] = LoadFromSharePoint(id);
           //if your LoadFromSharePoint is not that expensive.
           //mind you this is little different from your original 
           //approach as to what it does.
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
