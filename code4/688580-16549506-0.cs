    [Route("/path/{Id}", "GET, OPTIONS")]
    public class MyModel
    {
        public int Id { get; set; }
    
        public List<dynamic> SomeListItems { get; set; }
    }
    // in a controller or service
    var model = new MyModel() { Id = 1 };
    model.SomeListItems =  new List<dynamic> {
      new { Key = 1, Value = "foo }, new {Key = 2, Value = "bar" }
    }; // this should serialize to JSON as { Id: 1, SomeListItems: [ {Key: 1, Value: 'foo'}, {Key:2, Value = 'bar'}]}; which angular can handle nicely
