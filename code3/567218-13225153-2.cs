        FormB frmB = new FormB(frmA);
        //...
        public partial class FormB : Form
        {
            public FormB()
            {
                InitializeComponent();
            }
            //parameterized constructor
            public FormB(FormA obj)
            {
                FormA = obj;
                InitializeComponent();
            }
    
            public FormA FormA { get; set; }   
        }
