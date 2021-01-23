    public class ExampleWithField
    { 
        public ExampleWithField(){ 
            this.name = "Not our name"; // the value will be "Not our name"
        }
        private readonly string name = "ourName";
    }
    public class ExampleWithProperty
    { 
        public ExampleWithProperty(){ 
            this.name = "Not our name"; // this will not compile.
        }
        private string name { get { return "ourName" } }
    }
