    public class MyButton : System.Windows.Forms.Button, MyInterface
    {
        public string MyProperty
        {
            get { return null; }
            set { /* ??? */ }
        }
        public string MyProp { get; set; } // <------ Implement string MyProp
    }
