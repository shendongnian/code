    [BeforeFeature]
    public void Background()
    {
      FeatureContext.Current["Host"] =new MyHostObject();
    }
    
    [When("I call GetAccount API method with password =\"(\.*)\"")]
    public void WhenICallGetAccount(string password)
    {
      var host = (MyHostObject)FeatureContext.Current["Host"];
      ScenarioContext.Current["Account"] = host.GetAccount(password);
    }
    [Then("the result should be success")]
    public void ThenTheResultShouldBeSuccessful()
    {
      var account = (MyAccount)ScenarioContext.Current["Account"];
      //assuming using Should;
      account.ShouldNotBeNull();
    }
