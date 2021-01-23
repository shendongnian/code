    public void TestSomething()
    {
        Test(new Action(this.SomeOddMethod));
    }
    private void SomeOddMethod()
    {
        Debug.WriteLine("Test");
    }
