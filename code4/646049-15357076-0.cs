    static void increment(int num) // here you have copy of x
    {
        num++; // copy is modified
    }
    
    static void Main(string[] args)
    {   
        int x = 30;
        Console.WriteLine(x);
        increment(x); // x stays here and not passed into method
        Console.WriteLine(x);
    }
