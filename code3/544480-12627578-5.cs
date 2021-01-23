    static void Main()
    {
        int x = 5; // Value type
        List<int> list = new List<int>(new [] { 1, 2, 3 }); // Reference type
        
        ValueByValue(x); // x is still 5
        ReferenceByValue(list) // list still contains { 1, 2, 3 }
        ValueByReference(ref x); // x is now 10
        ReferenceByReference(ref list); // list is now a new list containing only { 4, 5, 6 }
    }
    
    static void ValueByValue(int x)
    {
        x = 10; // Changes local COPY of x
    }
    
    static void ReferenceByValue(List<int> list)
    {
        list = new List<int>(new [] { 4, 5, 6 }); // Changes local COPY of list
    }
    
    static void ValueByReference(ref int x)
    {
        x = 10; // Changes the actual x variable in the Main method
    }
    
    static void ReferenceByReference(ref List<int> list)
    {
        list = new List<int>(new [] { 4, 5, 6 }); // Changes the actual list in the Main method
    }
