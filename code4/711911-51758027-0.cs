    public int value1 = 3;
    public int value2 = 4;
    public int value3 = 5;
    public void Method1()
    {
        int[] values = { value1, value2, value3};
        for (int i = 0; i < values.Length; i ++)
        {
            Console.WriteLine(values[i]);
        }
    }
