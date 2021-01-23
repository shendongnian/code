    public class Foo
    {
        public void DoSomething<T>()
        {
            if(typeof(T).IsEnum)
            {
               //Do Something
            } else if (typeof(T).IsClass)
            {
               var bar = new Bar();
                
               //Problem How to call bar as type T must be a reference type?
                bar.GetData<T>();
            }     
        }
    }
    
    public class Bar
    {
        public IProvideList<T> GetData<T>() //where T : class
        {
            //Do Something
        }
    }
    
    public interface IProvideList<T> //where T : class
    {
    
    }
