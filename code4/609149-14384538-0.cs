    // ICacheable interface is used as a flag for cacheable classes
    public interface ICacheable
    {
    }
    
    // Videos and Images are ICacheable
    public class Video : ICacheable
    {
        public String Title { get; set; }
    }
    
    public class Image : ICacheable
    {
        public String Title { get; set; }
    }
    
    // CacheStore will keep all objects loaded for a class, 
    // as well as the hashcodes of the predicates used to load these objects
    public class CacheStore<T> where T : ICacheable
    {
        static List<T> loadedObjects = new List<T>();
        static List<int> loadedPredicatesHashCodes = new List<int>();
    
        public static List<T> GetObjects(Expression<Func<T, bool>> predicate) 
        {
            if (loadedPredicatesHashCodes.Contains(predicate.GetHashCode<T>()))
                // objects corresponding to this predicate are in the cache, filter all cached objects with predicate
                return loadedObjects.Where(predicate.Compile()).ToList();
            else
                return null;
        }
        
        // Store objects in the cache, as well as the predicates used to load them    
        public static void StoreObjects(List<T> objects, Expression<Func<T, bool>> predicate)
        {
            var hashCode = predicate.GetHashCode<T>();
            if (!loadedPredicatesHashCodes.Contains(hashCode))
            {
                loadedPredicatesHashCodes.Add(hashCode);
                loadedObjects = loadedObjects.Union(objects).ToList();
            }
        }
    }
    // DbLoader for objets of a given class
    public class DbStore<T> where T : ICacheable
    {
        public static List<T> GetDbObjects(Expression<Func<T, bool>> predicate)
        {
            return new List<T>(); // in real life, load objects from  Db, with predicate
        }
    }
    // your redis cache
    public class RedisCache
    {
        public static List<T> GetList<T>(Expression<Func<T, bool>> predicate) where T:ICacheable
        {
            // try to load from cache
            var objList = CacheStore<T>.GetObjects(predicate);
            if(objList == null)
            {
                // cache does not contains objects, load from db
                objList = DbStore<T>.GetDbObjects(predicate);
                // store in cache
                CacheStore<T>.StoreObjects(objList,predicate);
            }
            return objList;
        }
    }
    // example of using cache
    public class useRedisCache
    {
        List<Video> videos = RedisCache.GetList<Video>(v => v.Title.Contains("some text"));
        List<Image> images = RedisCache.GetList<Image>(i => i.Title.Contains("another text"));
    }
    
    // utility for serializing a predicate and get a hashcode (might be useless, depending on .Equals result on two equivalent predicates)
    public static class PredicateSerializer
    {
        public static int GetHashCode<T>(this Expression<Func<T, bool>> predicate) where T : ICacheable
        {
            var serializer = new XmlSerializer(typeof(Expression<Func<T, bool>>));
            var strw = new StringWriter();
            var sw = XmlWriter.Create(strw);
            serializer.Serialize(sw, predicate);
            sw.Close();
            return strw.ToString().GetHashCode();
        }
    }
