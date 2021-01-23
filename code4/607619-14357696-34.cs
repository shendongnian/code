    void MyWayTwo(int s1, int s2, int p1, int p2, int v)
    {
        p1 += p2;
        s1 += s2;
        for (int i = 1 << v, p = i << 1; i < p; i++)
        {
            for (int m = i; (m & 1) == 0; m >>= 1)
                s1 += p1;
            Console.WriteLine(s1);
        }
    }
