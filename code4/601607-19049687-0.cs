    public void Linq94() 
    { 
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
        int[] numbersB = { 1, 3, 5, 7, 8 }; 
      
        var allNumbers = numbersA.Concat(numbersB); 
      
        Console.WriteLine("All numbers from both arrays:"); 
        foreach (var n in allNumbers) 
        { 
            Console.WriteLine(n); 
        } 
    }
