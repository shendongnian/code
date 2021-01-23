    public void Get([FromUri] SomeParams p){
      //bound from the query string (more like MVC traditional binding)
    }
    public void Post(SomeParams p){
      //'p' is bound from your JSON (assuming correct format)
      //because 'complex' types are deserialized using formatters
      //only one object can be read from the body with a formatter in Web API
      //as the request body is not buffered; unlike MVC.
    }
