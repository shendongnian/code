    public static void Swap(double[] values, int firstIndex, int secondIndex)
    {
        double temp = values[start];
        values[start] = values[finish];
        values[finish] = temp;
    }
    public static void Reverse( double [] values, int start, int finish)
    {
        do
        {
            Swap(values, start, finish);
            start++;
            finish--;
        }
        while (start < finish);
    }
    static void Main(string[] args)
    {
        double[] data = { 8.5, 12.0, 23.2, 18.0, 15.5, 5.0, 10.5 };
        Reverse(data, 2, 5);
        foreach (double number in data)
            Console.Write(number.ToString() + ", ");
        Console.ReadKey();
    }
