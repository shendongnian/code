    [Binding]
    public class HttpRequestSteps
    {
        [When(@"the method assigned is (.*)")]
        public void WhenTheMethodAssignedIs(string method)
        {
            // not sure what this should be returning, but you can store it in ScenarioContext and retrieve it in a later step binding by casting back based on key
            // e.g. var request = (HttpRequest)ScenarioContext.Current["Request"]
            ScenarioContent.Current["Request"] = _request.AsGet();
        }
    }
