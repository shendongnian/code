    void Method1() { Console.WriteLine("M1"); }
    void Method2() { Console.WriteLine("M2"); }
    void SuperMethod(int nr)
    {
        var mi = this.GetType().GetMethod("Method" + nr, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        mi.Invoke(this, null);
    }
