    public delegate void Handler(object val);
    public delegate void Handler<T>(T val);
    public class HandlerRepository
    {
      private Dictionary<Type, Handler>  handlers = new Dictionary<Type, Handler>();
      
      public void RegisterHandler<T>(Handler<T> handler)
      {
         //error checking omitted
         //create a non-generic handler that calls the generic handler 
         //with the correct type.
         handlers.Add(typeof(T), (value)=>handler((T)value));
      }
      
      public void ExecuteHandler<T>(T value)
      {
         //error checking ommited
         handlers[typeof(T)](value);
      }
    }
