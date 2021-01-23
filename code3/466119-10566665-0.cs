    public Class MainForm : Form
    {
        public event Action MyEvent;
    
        MyUserControl MyControl = new MyUserControl(this);
        private void Button_Click(object sender, EventArgs e)
        {
            if(simpleEvent != null) simpleEvent();
        }    
    }
    
    public Class MyUserControl : UserControl
    {
        //listen for MyEvent from MainForm, and perform MyMethod
        public MyUserControl(MainForm form) {
            simpleEvent += () => MyMethod();
        }
    
        public void MyMethod()
        {
             //Do Stuff here
        }
    }
