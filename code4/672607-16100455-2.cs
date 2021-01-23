    public class MyViewModel
    {
        [CombinedMinLength(20, "Bar", "Baz", ErrorMessage = "The combined minimum length of the Foo, Bar and Baz properties should be longer than 20")]
        public string Foo { get; set; }
        public string Bar { get; set; }
        public string Baz { get; set; }
    }
