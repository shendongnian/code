    void Main()
    {
        var filter = GetX() + GetY() + GetZ();
        filter().Dump();
    }
    
    public int X() { Debug.WriteLine("X()"); return 1; }
    public int Y() { Debug.WriteLine("Y()"); return 2; }
    public int Z() { Debug.WriteLine("Z()"); return 3; }
    
    public Func<int> GetX() { return X; }
    public Func<int> GetY() { return Y; }
    public Func<int> GetZ() { return Z; }
