    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UserControl2 myUserControl2 = new UserControl2();
            myUserControl2.Top = this.Top + this.Height;  //Position new Control
            myUserControl2.Left = this.Left;              //Position new Control
            this.Parent.Controls.Add(myUserControl2);     //Add it to this Controls Parent
        }
    }
