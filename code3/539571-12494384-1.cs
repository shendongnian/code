    static void Main(string[] args)
    {
        var seq = Enumerable.Range(0, 12).Select(i => (decimal)i);
        Console.WriteLine(GetGreaterThanZero(seq));
    
        var arr = seq.ToArray();
        SetMinNull(arr);
        foreach(var n in arr)
            Console.WriteLine(n);
    }
    
    static int GetGreaterThanZero(IEnumerable<decimal> numbers)
    {
        return numbers.Count(n => n > 0);
    }
    
    static void SetMinNull(decimal[] numbers)
    {
        decimal min = numbers.Min();
    
        // edit: credits to daniel for this loop
        for(int i = 0; i < numbers.Length; i++)
        {
            if(numbers[i] == min) numbers[i] = 0;
        }
    }
