    public class Foo<T>
       where T : struct
    {
       object[] values = new object[5];
    
       public void Add(T value, int index)
       {
           values[index] = value;
       }
    
       public void Delete(int index)
       {
           values[index] = default(T);
       }
    }
