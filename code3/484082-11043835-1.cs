    private static void PrintHex(byte[] data)
    {
        for (int ctr = 0; ctr < 64 && ctr < data.Length; ctr++)
        {
            string sep;
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
