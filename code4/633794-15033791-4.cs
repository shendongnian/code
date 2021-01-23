    private void Application_Startup(object sender, StartupEventArgs e)
    {
        this.RootVisual = new MainPage();
        HtmlPage.RegisterCreatableType("TestClass", typeof(TestClass));
        HtmlPage.RegisterScriptableObject("scripTestClassObj", new TestClass());
    }
