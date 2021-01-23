    public class SomeParams {
      public string name { get; set; }
      public string email { get; set; }
    }
    //now an alternative way to write the Get method
    public MyResult Get([FromUri] SomeParams p){
      //members are bound from the query string (more like MVC traditional binding)
      //note - as in MVC, SomeParams will need a default constructor for this to work.
    }
    public PostResult Post(SomeParams p){
      //'p' is bound from your JSON (assuming correct format)
      //because 'complex' types are deserialized using formatters
      //only one object can be read from the body with a formatter in Web API
      //as the request body is not buffered; unlike MVC.
    }
