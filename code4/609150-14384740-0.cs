    public MyBaseObject<T>
    {
        public List<T> GetObjects<T>(Expression<Func<T, bool>> predicate) where T : ICacheable
        {
            return db.CreateObjectSet<T>().Where(predicate).ToList();
        }
    }
    public partial class Image : MyBaseObject<Image>, ICacheable
    {
    }
    public partial class Video : MyBaseObject<Video>, ICacheable
    {
    }
