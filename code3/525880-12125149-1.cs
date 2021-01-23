      public abstract class CreateBase<T> where T : CreateBase<T> , new()
      {
        public DateTime CreateDate { get; set; }
        public Guid Guid { get; set; }
    
        public static T Create(Action<T> init)
        {
          T obj = new T();
          obj.Guid = Guid.NewGuid();
          obj.CreateDate = DateTime.Now;
          init(obj);
          return obj;
        }
      }
    
      public class User : CreateBase<User>
      {
        public string Name { get; set; }
      }
