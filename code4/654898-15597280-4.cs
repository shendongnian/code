    public class Element<T>
    {
       public Element<T> Next { get; set; }
       public T Value { get; set; }
       
       public Element(T value, Element<T> next)
       {
           Next = next;
           Value = value;
       }
    }
