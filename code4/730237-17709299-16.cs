    void Main()
    {
        int x = 10;
        Test(() => Debug.WriteLine("x=" + x));
    }
    
    public void Test(Action action)
    {
        action();
    }
