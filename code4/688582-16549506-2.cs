    [Route("/path/{Id}", "GET, OPTIONS")]
    public class MyModel
    {
        public int Id { get; set; }
    
        public List<JsonPayload> SomeListItems { get; set; }
    }
