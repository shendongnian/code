    public HttpResponseMessage Post(ValueModel model)
    {
        return Request.CreateResponse<string>(HttpStatusCode.OK, "Value Recieved: " + model.Value);
    }
    public class ValueModel
    {
        public string Value { get; set; }
    }
