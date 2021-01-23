    public class ValuesController : ApiController
    {
        [System.Web.Http.AcceptVerbs("POST")]
        public bool POST(CustomListType myList)
        {
            //Do stuff here
            return true;
        }
        public class CustomListType
        {
            public List<int> myArray { get; set; }
        }
    }
