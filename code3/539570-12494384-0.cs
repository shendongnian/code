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
        var m = new SortedDictionary<decimal, int>();
    
        for(int i = 0; i < numbers.Length; i++)
        {
            if(m.Count < 2)
            {
                m.Add(numbers[i], i);
            }
            else if(m.Keys.Max() > numbers[i])
            {
                m.Remove(m.Keys.Max());
                m.Add(numbers[i], i);
            }
        }
    
        foreach(var i in m.Values)
        {
            numbers[i] = 0;
        }
    }
