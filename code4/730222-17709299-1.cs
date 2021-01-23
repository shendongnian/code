    public void TestSomething()
    {
        var temp = new SomeClass;
        Test(new Action(temp.SomeOddMethod));
    }
    private class SomeClass
    {
        private void SomeOddMethod()
        {
            Debug.WriteLine("Test");
        }
    }
