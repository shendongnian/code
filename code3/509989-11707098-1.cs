    void Main()
    {
    var x = Add<string>(new { val = "hello"},new { val = "world"});  // Returns "hello world"  
    Console.WriteLine(x);
    }
    
    // Define other methods and classes here
    T Add<T>(dynamic a, dynamic b)
    {
        return a.val + b.val;
    }
