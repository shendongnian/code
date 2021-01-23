    public class MyModel
    {
        public string RaceName{get; set;}
        public int StatOrigValue{get; set;}
        public int FreePts{get; set;}
    }
    
    [HttpPost]
    public JsonResult SomeMethod(MyModel sampledata)
    {
        //do stuff here
       return new JsonResult {Data =  new {Success = "Success"}}
    }
