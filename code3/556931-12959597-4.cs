    public class TestController: ApiController
    {
        [System.Web.Http.HttpPost]
        public string TestAction(MyViewModel model)
        {
            return "test";
        }
    }
