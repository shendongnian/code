    private static TestContext contextSave;
    [ClassInitialize]
    public static void DoOneTime(TestContext context)
    {
        string AUTExecutable = ConfigurationManager.AppSettings["AUTExecutable"];
        _aut = ApplicationUnderTest.Launch(AUTExecutable );
        context.Properties.Add("AUT", _aut);
        contextSave = context;
    }
    [TestMethod]
    public void Test01()
    {
       //...
       DoSthmWithAUT(context.Properties["AUT"]);
    }
    [TestMethod]
    public void Test02()
    {
        DoOtherWithAUT(context.Properties["AUT"]);
    }
    [ClassCleanup]
    public static void Cleanup()
    {
         contextSave = null;
    }
