    public class Test
    {
        private string test; // will not be in DeclaredProperties
        private string test2 { get; set; } // will be in DeclaredProperties
        public int test3{ get; set; }  // will be in DeclaredProperties
    }
    var result = typeof(Test).GetTypeInfo().DeclaredProperties;
