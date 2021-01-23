    void Main() 
    { 
        List<int> foo = new List<int>(){1,2,3}; 
        IEnumerable<int> bar = GetNumbers(foo); 
        Console.WriteLine(foo.Count); // prints 3
        Iterate(bar); 
        Console.WriteLine(foo.Count); // prints 0
        Iterate(bar); 
    } 
