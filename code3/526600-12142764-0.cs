    static void Main(string[] args)
    {
         ClassA obj = new ClassC(); 
         Console.WriteLine(obj.Get());  // will print out "from B"
         ClassC obj2 = new ClassC(); 
         Console.WriteLine(obj2.Get());  // will print out "from C"
    }
