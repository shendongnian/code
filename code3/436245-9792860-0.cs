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
    }
    var A = new ReferenceContainer<string>("abc");
    var B = A;
    B.Value = "abcd";
    Console.WriteLine(A);//abcb
    Console.WriteLine(B);//abcd
        
