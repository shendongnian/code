    public class DataController : ApiController
    {
        public void Post(DataModel model)
        {
            // Whether the body contains XML, JSON, or Url-form-encoded it will be deserialized
            // into the model object which you can then interact with in a strongly-typed manner
        }
    }
    public class DataModel
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
    }
