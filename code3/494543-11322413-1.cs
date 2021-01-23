    static void output(Array arr)
    {
        for (int v = 0; v < arr.Length; v++)
        {
            string number = "Value: ";
            string arrayPoint = "Array Section: ";
            Console.WriteLine("{0}{1}\t{2}{3}", arrayPoint, v, number, arr.GetValue(v));
        }
    }
