    public interface ICloneable<T> : ICloneable
        where T : class
    {
        T TypedClone();
    }
    
    public class MyCloneableObject : ICloneable<MyCloneableObject>
    {
         public string Some { get; set; }
    
         public object Clone()
         {
             MyCloneableObject clone = new MyCloneableObject { Some = this.Some };
         }
    
         public MyCloneableObject TypedClone()
         {
              return (MyCloneableObject)Clone();
         }
    }
