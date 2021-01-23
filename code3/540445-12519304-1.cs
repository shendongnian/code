    [Test] 
    public void SomeMethodTest_SelectListOptionPickedAndButtonClicked_TextboxHasExpectedValue()
    {
      using (var browser = new IE("http://yourpage.com"))
      {
       browser.SelectList("DdlId").Option("SomeOption").Select();
       browser.Button(Find.ByName("SomeButtonId")).Click();
       string textFieldValue = browser.TextField(Find.ByName("SomeTextFieldid")).Text;
         
       Assert.AreEqual("ExpectedValue", textFieldValue);
      }
    }
