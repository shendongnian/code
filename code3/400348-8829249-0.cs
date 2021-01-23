    const int SIZE = 10;
    int[] myValue = new int[SIZE];
    int start = 0;
    int count = 0;
    void NewValue(int v)
    {
        myValue[start] = v;
        if (count < SIZE)
            count++;
        start = (++start) % SIZE;
    }
    void ListValues()
    {
        for (int i = start - 1; i >= 0; i--)
            Console.WriteLine(myValue[i]);
        if (count >= SIZE)
            for (int i = SIZE - 1; i >= start; i--)
                Console.WriteLine(myValue[i]);
        Console.WriteLine();
    }
    private void Test()
    {
        for (int i = 0; i < 20; i++)
        {
            NewValue(i);
            ListValues();
        }
    }
