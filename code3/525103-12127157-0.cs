    void Main()
    {
        Console.WriteLine("Are there any evens? " + YieldEvenThenThrowEnumerable().Any(i => i % 2 == 0));
        Console.WriteLine("still running");
        Console.WriteLine("Are there any odds? " + YieldEvenThenThrowEnumerable().Any(i => i % 2 == 1));
        Console.WriteLine("never reaches this point");
    }
    
    IEnumerable<int> YieldEvenThenThrowEnumerable()
    {
        yield return 2;
        throw new InvalidOperationException("TEST");
    }
