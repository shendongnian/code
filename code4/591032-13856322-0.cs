    public interface IWebServiceWrapper
    {
        void DoStuffWith(Something something);
        SomethingElse GetSomeThingElse(int id);
    }
    public class ServiceWrapper : IWebServiceWrapper
    {
        private TheRealWebService _realWebService = new TheRealWebService();
        public void DoStuffWith(Something something)
        {
            _realWebService.DoStuffWith(something);
        }
         
        public SomethingElse GetSomeThingElse(int id)
        {
            _realWebService.GetSomeThingElse(id);
        }
         
    }
