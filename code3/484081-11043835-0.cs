    private static void PrintHex(byte[] data, uint len)
    {
        uint ctr;
        string sep;
        if (len > 64)
        {
            len = 64;
        }
        for (ctr = 0; ctr < len && ctr < data.Length; ctr++)
        {
            if (((ctr & 7) == 0) && (ctr != 0))
            {
                sep = "\n";
            }
            else
            {
                sep = "";
            }
            Console.Error.WriteLine("{0}{1:X}", sep, data[ctr]);
        }
        Console.Error.WriteLine("\n\n");
    }
