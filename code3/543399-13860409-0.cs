    public class MyClass
    {
        private string myPrivateField;
        public string MyPublicProperty { get; set; }
        public void MyMethod()
        {
            this.myPrivateField = "Cucumber";
            MyPublicProperty = "Cucumber as well";
        }
    }
