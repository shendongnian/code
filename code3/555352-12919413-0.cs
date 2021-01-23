    public class ObjWrapper<T> : IDisposable
    {
       private T dt = null;
    
       public ObjWrapper<T>(T data)
       {
          this.dt = data;
       }
    
       public void Dispose()
       {
          SaveKnownTypeInDB(this.dt);
       }
    }
