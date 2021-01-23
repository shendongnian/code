    [Test]
    public void DoSomeTest()
    {
        MyDependencyKernel kernel = new MyDependencyKernel();
        CokeConsumer steve = new CokeConsumer();
        steve.DrinkSomeCoke(100);
    }
