    public class ExampleClass {
        String myString = "Hello World!";
        
        public String MyProperty {
            get { return myString; }
            set {
                myString = value;
                System.Console.WriteLine("MyProperty changed to " + value);
            }
        }
    }
