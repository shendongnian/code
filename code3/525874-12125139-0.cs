    public abstract class CreateBase<T> where T : CreateBase, new()
    {
        public static T Create(Action<T> init) 
        {
            //...
        }
    }
    
    public class User : CreateBase<User>
    {
        public string Name { get; set; }
    }
