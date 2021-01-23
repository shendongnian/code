    static class Pages {
      public const String HomePage = "Home Page";
      public const String UserAccountPage = "User Account Page";
    }
    
    [TestCase(Pages.HomePage)]
    void TestMethod(Page p) { ...
