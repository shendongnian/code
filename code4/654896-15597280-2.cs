    public class Element<T>
    {
       public Element<T> Next;
       public T Value;
       
       public Element(T sValue, Element<T> sNext)
       {
           Next = sNext;
           Value = sValue;
       }
    }
