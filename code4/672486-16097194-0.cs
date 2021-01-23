    public class MyClass {
        [ArrayIndex(1)]
        public string a {get; set;}
        [ArrayIndex(2)]
        public string b {get; set;}
        public void ProcessData(IEnumerable<string> input) {
            // loop through input and use reflection to find the property corresponding to the index
        }
    }
