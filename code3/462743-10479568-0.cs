    static void Main(string[] args)
    {
        IList<string> strings = new List<string> { "a", "b", "c" };
        IList<object> objects = strings;  ** // This will give an error because compiler does not want you to do the line below **
        objects.Add(5);  // Type safety violated for IList<string> hence not allowed
        // The code below works fine as you cannot modify the strings collection using IEnumerable of object
        //IEnumerable<string> strings = new List<string> { "a", "b", "c" };
        //IEnumerable<object> objects = strings;
    }
