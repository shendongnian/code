    private static void f(string x, int y)
    {
        Console.WriteLine("{0}: {1}", x, y);
    }
    private static void Main(string[] args)
    {
        List<Action> qs = new List<Action>();
        <>c__DisplayClass1 CS$<>8__locals2 = new <>c__DisplayClass1();
        CS$<>8__locals2.i = 0;
        while (CS$<>8__locals2.i < 10)
        {
            qs.Add(new Action(CS$<>8__locals2.<Main>b__0));
            CS$<>8__locals2.i++;
        }
        for (int i = 0; i < 10; i++)
        {
            qs[i]();
        }
    }
    [CompilerGenerated]
    private sealed class <>c__DisplayClass1
    {
        // Fields
        public int i;
    
        // Methods
        public void <Main>b__0()
        {
            Program.f("doer", this.i);
        }
    }
