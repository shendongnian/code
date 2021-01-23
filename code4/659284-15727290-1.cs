    public partial class login : UserControl
    {
        Form1 _parent;                       //ADD THIS
        public login(Form1 parent)
        {
            InitializeComponent();
            this._parent = parent;          //ADD THIS
        }
        public void button1_Click_1(object sender, EventArgs e)
        {
             this._parent.mytest();         //CALL WHAT YOU WANT
        }
    }
