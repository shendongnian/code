    int n1 = 0;
    int n2 = 0;
    void Test2(int i1, int i2, int v)
    {
        Stack<int> s = new Stack<int>(new[] {v});
        n1 = i1 + i2;
        while (s.Any())
        {
            v = s.Pop();
            if (v == 0)
            {
                Console.Out.WriteLine(n1 + n2);
            }
            else
            {
                int tmp = n1;
                n1 = n2 + 10;
                n2 = tmp + 20;
                s.Push(v - 1);
                s.Push(v - 1);
            }
        }
    }
