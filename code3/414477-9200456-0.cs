        public class MyButton : System.Windows.Forms.Button, MyInterface
        {
            public string Myproperty
            {
                get { return null; }
                set { /* ??? */ }
            }
            public string MyProp { get; set; } // <------ Implement string MyProp
        }
