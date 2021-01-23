    public class ClassUsingConstraints<T> where T : IComparable<T>
    {
       public static void method(T stuff)
       {
           stuff.CompareTo(stuff);  
       }
    }
