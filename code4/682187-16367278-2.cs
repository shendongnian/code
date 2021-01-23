    public class ExampleWithField
    { 
        public ExampleWithField(){ 
            this.name = "Not our name"; // the value will be "Not our name"
        }
        private readonly string name = "ourName";
    }
    public class ExampleWithFieldAndRefParam
    { 
        public ExampleWithFieldAndRefParam(){ 
            SetRefValue(ref this.name); // the value will be "Not our nameourName"
        }
        static void SetRefValue(ref string value){ value = "Not our name" + value; }
        private readonly string name = "ourName";
    }
    public class ExampleWithFieldAndOutParam
    { 
        public ExampleWithFieldAndOutParam(){ 
            SetOutValue(out this.name); // the value will be "Not our name"
        }
        static void SetOutValue(out string value){ value = "Not our name"; }
        private readonly string name = "ourName";
    }
    public class ExampleWithProperty
    { 
        public ExampleWithProperty(){ 
            this.name = "Not our name"; // this will not compile.
        }
        private string name { get { return "ourName"; } }
    }
 
