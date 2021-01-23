    public interface A: IClonable { 
        Initialize();
    }
    public static List<A> CreateList(A baseA, int length)
    {
        List<A> myList = new List<A>();
        for (int i = 0; i < length; i++)
        {
           var copy = (A) baseA.Clone();
           copy.initialize();
           myList.Add(copy);
        }
        return myList;
    }
