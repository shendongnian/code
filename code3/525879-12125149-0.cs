    public abstract class CreateBase<T> where T : CreateBase, new()
    {
        public DateTime CreateDate { get; set; }
        public Guid Guid { get; set; }
    
        public static T Create<T>(Action<T> init) 
        {
        T obj = new T();
        obj.Guid = Guid.NewGuid();
        obj.DateTime = DateTime.Now;
        init(obj);
        return obj;
        }
    }
    public class User : CreateBase<User>
    {
        public string Name { get; set; }
    }
