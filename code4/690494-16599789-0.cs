    public class Factory {
       private static Dictionary<Type, Func<Model>> creators;
       public void AddCreator<T>(Func<T> creator) where T:Model
       {
          creators.Add(typeof(T), ()=> creator());
       }
       public static T Instance() where T : Model 
       {
           return (T)(creators[typeof(T)] ());
       }
    }
