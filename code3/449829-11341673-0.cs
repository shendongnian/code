    [SetUp]
    public void init()
    {
        _browser = new DefaultSelenium("localhost", 4444, @"*iehta",   "http://localhost:4444");
        _browser.Start();
        _browser.Open("http://localhost/testSite.asp");
    }
    [TestMethod]
    public  void TestLogin()
    {
        bool hasText;
        
        _browser.Type("id=NomUtilisateur", "admin");
        _browser.Type("id=UserPassword", "password");
        _browser.Click("name=Submit");
        _browser.WaitForPageToLoad("30000");
        hasText = _browser.IsTextPresent("test");
        Assert.IsTrue(hasText, @"The search result does not contain text ""test"".");
    }
    [TestMethod]
    public void TestRequisitionPhotocopie()
    {
        _browser.Type("id=NomUtilisateur", "admin");
        _browser.Type("id=UserPassword", "password");
        _browser.Click("name=Submit");
        _browser.WaitForPageToLoad("30000");
        _browser.Click("link=lnkTest");
        _browser.WaitForPageToLoad("30000");
    }
    [TearDown]
    public void clean()
    {
        _browser.Stop();
        //_browser.Close();
    }
