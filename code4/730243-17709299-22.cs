    void Main()
    {
        int x = 10;
        Test(delegate { Debug.WriteLine("x=" + x); });
    }
    
    public void Test(Action action)
    {
        action();
    }
