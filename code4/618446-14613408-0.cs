    public static void Method(int flowerInVase)
    {
       if (flowerInVase > 0)
       {
           Console.WriteLine(flowerInVase);
           Method(flowerInVase - 1);
       }
    }
