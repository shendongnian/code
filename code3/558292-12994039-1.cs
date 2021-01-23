    public void PrintList()
    {
       Console.WriteLine("Numbers count: " + numbers.Count);    
       for (int i = 0; i < numbers.Count; i++)   
           Console.WriteLine("Numbers: {0}\tIteration: {1}", numbers[i], i);       
    
       Console.WriteLine("Letters count: " + letters.Count);    
       for (int i = 0; i < letters.Count; i++)       
           Console.WriteLine("Letters : {0}\tIteration: {1}", letters[i], i);   
    }
