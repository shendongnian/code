    public class DataObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ActionsController : ApiController
    {
        // GET api/actions
        public DataObject Get()
        {
            var testObject = new DataObject
            {
                Name = "Test name",
                Description = "Test Description"
            };
            return testObject;
        }
    }
