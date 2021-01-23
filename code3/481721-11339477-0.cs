    public HttpResponseMessage Post(ValueModel model)
    {
        return Request.CreateResponse<string>(HttpStatusCode.OK, "Value Recieved: " + model.Value);
    }
    public class ValueModel
    {
        public string Value { get; set; }
    }
    { "value": "In MVC4 Beta you could map to simple types like string, but testing with RC 2012 I have only been able to map to DataModels and only JSON (application/json) and url-encoded (application/x-www-form-urlencoded body formats have worked. XML is not working for some reason" }
