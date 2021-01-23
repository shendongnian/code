    void Main()
    {
        Func<int> x = X;
        Func<int> y = Y;
        Func<int> z = Z;
        
        var filter = x + y + z;
        filter().Dump();
    }
    
    public int X() { Debug.WriteLine("X()"); return 1; }
    public int Y() { Debug.WriteLine("Y()"); return 2; }
    public int Z() { Debug.WriteLine("Z()"); return 3; }
