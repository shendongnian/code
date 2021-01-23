    public partial class section1 : UserControl
    {
        private Form1 f { get; set; }
    
        public section1() // designer calls this
        {
            InitializeComponent(); //I hope you haven't forgotten this
        }
    
        public section1(Form1 frm) : this() //call default from here : at runtime
        {
             f = frm;
        }
    }
