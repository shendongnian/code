    public class Class1 {
        protected String String1 { get; set; }
    }
    public class Class2 : Class1 {
        public String String2 {
            get {
                String PropertyFromClass1 = base.String1;
                // ...
            }
        }
    }
