    static IEnumerable<int> YieldFun()
    {
        int[] numbers = new int[3] { 1, 2, 3 };
        if (numbers.Count() == 3)
            throw new Exception("Test...");
        return YieldFunImpl(numbers);
    }
    static IEnumerable<int> YieldFunImpl(int []numbers)
    {
        //This code continues even an exception was thrown above.
        foreach (int i in numbers)
        {
            if (i % 2 == 1)
                yield return numbers[i];
        }
    }
    static void Main(string[] args)
    {
        IEnumerable<int> result = null;
        try
        {
            result = YieldFun();
        }
        catch (System.Exception ex) //Cannot catch the exception
        {
            Console.WriteLine(ex.Message);
        }
        foreach (int i in result)
        {
            Console.Write(" " + i);
        }
    }
}
