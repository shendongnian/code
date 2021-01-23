    public class Class1 {
        private string Name1;
        public Class1(string subclassName2)
        {
            // Subclass has passed its Name2 here
        }  
    }
    public class Class2: class1 {
        private string Name2; 
        public Class2(string myName) : base(myName) {
            Name2 = myName;
        }
    }
