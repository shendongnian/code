    class SomeMainClass
    {
        private ClassB form = null;
    
        private void SomeMethod()
        {
            form = new ClassB();
            form.Show();
            ClassA foo = new ClassA(this);
        }
        
        // Use an accessor.
        public ClassB Form
        {
            get { return this.form; }
        }
    }
    
    class ClassA
    {
        private SomeMainClass mainClass = null;
    
        // Constructor.
        public ClassA(SomeMainClass _mainClass)
        {
            this.mainClass = _mainClass;
        }
    
        private void SomeMethod()
        {
            this.mainClass.Form.Print("Something to print");
        }
    }
    
    class ClassB : Form
    {
        // Constructor.
        public ClassB()
        {
            InitializeComponent();
        }
    
        public void Print(String text) 
        {     
            rtb_log.appendText("\n" + text); 
        } 
    }   
