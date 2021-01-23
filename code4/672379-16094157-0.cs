    Random r = new Random();
    StringBuilder b = new StringBuilder("0101");
    for (int i = 0; i < 4; i++)
    {
        int MutProbablity = r.Next(1, 1000);
        if (MutProbablity == 5)
        {
            b[i] = (b[i] == '0' ? '1' : '0');
        }
    }
    Console.WriteLine(b.ToString());
