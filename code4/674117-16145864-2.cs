    namespace WcfService1
    {
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MyService : IMyService
    {
        public string Test()
        {
            return "Test";
        }
    }
    }
