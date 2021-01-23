    [Test]
    public void Should_attach_to_browser()
    {
         ExecuteTest(browser =>
         {
              browser.GoTo(NewWindowUri);
              browser.Link(Find.First()).Click();
              var findBy = Find.ByTitle("New window");
              var newWindow = Browswer.AttachTo(browser.GetType(), findBy);
              newWindow.Close();
         });          
    }
