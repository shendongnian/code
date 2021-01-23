    unsafe
    {
        fixed (decimal* array = new decimal[2])
        {
            array[0] = 10M;
            array[1] = 10.00M;
            byte* ptr = (byte*)array;
            Console.Write("10M:    ");
            for (int i = 0; i < 16; i++)
                Console.Write(ptr[i].ToString("X2") + " ");
            Console.WriteLine("");
            Console.Write("10.00M: ");
            for (int i = 16; i < 32; i++)
                Console.Write(ptr[i].ToString("X2") + " ");
        }
    }
