    // TODO: check for index fit array range
    public class Foo<T>
       where T : struct
    {
       object[] values = new object[5];
    
       public void Add(T value, int index)
       {
           // TODO: do not allow to add default values to array
           values[index] = value;
       }
    
       public void Delete(int index)
       {
           values[index] = default(T);
       }
    }
