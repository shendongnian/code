    var num1;
    
    Console.WriteLine("Accept number:");
    num1 = Convert.ToInt32(Console.ReadLine());
    if(IsPrime(num1))
    {
      Console.WriteLine("It is prime");
    }
    else
    {
      Console.WriteLine("It is not prime");
    }       
    
    public static bool IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;
        var boundary = (int)Math.Floor(Math.Sqrt(number));
              
        for (int i = 2; i <= boundary; ++i)
        {
            if (number % i == 0)  return false;
        }
        
        return true;        
    }
