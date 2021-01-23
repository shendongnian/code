    public class SomeThingController : ApiController
    {
        [HttpGet]
        public IEnumerable<SomeThing> Search(DateTime minDate, DateTime maxDate, bool summaryOnly = true)
        {
            ...
        }
    }
