    public void PrintList()
    {
       Console.WriteLine("Numbers count: " + numbers.Count);
    
       for (int i = 0; i < numbers.Count; i++)   
           Console.WriteLine("Numbers: " + numbers[i] + "\tIteration: " + i);
       
    
       Console.WriteLine("Letters count: " + letters.Count);
    
       for (int i = 0; i < letters.Capacity; i++)       
           Console.WriteLine("Letters : " + letters[i] + "\tIteration: " + i);   
    }
