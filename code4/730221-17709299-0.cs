    public void TestSomething()
    {
        Test(new Action(SomeOddMethod));
    }
    private void SomeOddMethod()
    {
        Debug.WriteLine("Test");
    }
