    public static System.Collections.IEnumerable CountToTen()
    {
        int counter = 0;
        while (counter++ < 10)
        {
            yield return counter;
        }
    }
    public static Main(string[]...)
    {
        foreach(var i in CountToTen())
        {
            Console.WriteLine(i);
        }
    }
