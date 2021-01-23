    static void Main(string[] args)
    {
        Console.WriteLine(ReturnO(true).ToString());  //"{ }"
        Console.WriteLine(ReturnO(false).ToString());  // "System.Object"
    
        Console.WriteLine(ReturnO(true).Equals(ReturnO(true)));  //True
        Console.WriteLine(ReturnO(false).Equals(ReturnO(false)));  //False
        Console.WriteLine(ReturnO(false).Equals(ReturnO(true)));  //False
    
        Console.WriteLine(ReturnO(true).GetHashCode());  //0
        Console.WriteLine(ReturnO(false).GetHashCode());  //37121646
    
        Console.ReadLine();
    }
    
    static object ReturnO(bool anonymous)
    {
        if (anonymous) return new { };
        return new object();
    }
