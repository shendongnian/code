    public void Test()
    {
        int x = 10;
        Test(delegate { Debug.WriteLine("x=" + x); });
    }
