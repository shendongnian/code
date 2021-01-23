    void MyWayTwo(int start1, int start2, int plus1, int plus2, int v)
    {
        plus1 += plus2;
        int n = start1 + start2 + plus1 * v;
        for (int i = 0, pow = 1 << v; i < pow; i++)
        {
            for (int mask = i; mask > 0 && (mask & 1) == 0; mask >>= 1)
                n += plus1;
            Console.WriteLine(n);
        }
    }
