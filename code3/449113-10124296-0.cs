    public class TestableNavigationService : INavigationService
    {
        Dictionary<string, Parameters> Calls = new Dictionary<string, Parameters>();
        public void Navigate(string page, string parameterName, string parameterValue)
        {
            Calls.Add("Navigate" new Parameters()); // Parameters will need to catch the parameters that were passed to this method some how
        }
        public void Verify(string methodName, Parameters methodParameters)
        {
            ASsert.IsTrue(Calls.ContainsKey(methodName));
            // TODO: Verify the parameters are called correctly.
        }
    }
