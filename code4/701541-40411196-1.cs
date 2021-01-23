    public void TestMethod1()
    {
        TestContext.BeginTimer("Overall");
        for (int i = 0; i < 5; i++)
        {
            TestContext.BeginTimer("Per");
            doAction();
            TestContext.EndTimer("Per");
            Sleep(1000);
        }
        TestContext.EndTimer("Overall");
    }
   
