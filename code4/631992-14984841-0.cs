    static void print(object o)
    {
        Console.WriteLine(IsIEnum(o));       // Always returns false
        var o2 = o as IEnumerable;     // Exception on arrays of primitives
        if(o2 != null) {
          foreach(var i in o2) {
            Console.WriteLine(i);
          }
        } 
    }
