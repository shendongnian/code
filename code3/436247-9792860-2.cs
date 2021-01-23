    public class ReferenceContainer<T>
    {
         public T Value {get;set;}
         public ReferenceContainer(T item)
         {
             Value = item;
         }
         public override string ToString()
         {
            return Value.ToString();
         }
         public static implicit operator T (ReferenceContainer<T> item)
         {
             return Value;
         }
    }
    var A = new ReferenceContainer<string>("X");
    var B = A;
    B.Value = "Y";
    Console.WriteLine(A);// ----> Y
    Console.WriteLine(B);// ----> Y
        
