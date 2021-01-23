    public void TestSomething()
    {
        var temp = new SomeClass;
        temp.x = 10;
        Test(new Action(temp.SomeOddMethod));
    }
    private class SomeClass
    {
        public int x;
        private void SomeOddMethod()
        {
            Debug.WriteLine("x=" + x);
        }
    }
