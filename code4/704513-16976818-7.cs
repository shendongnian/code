    public static void rand()
    {
         for(int j = 0; j < 10; j++)
         {
              Random r = new Random(j);
              Console.WriteLine(r.Next(100));
         }
    }
