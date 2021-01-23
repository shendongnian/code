    public class TestWebService
    {
        [WebMethod]
        public string Hello(string namex)
        {
            return "Hello " + namex;
        }
    }
