    public partial class UserControl1 : UserControl
    {
        MyMessageBox msgbox; 
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            msgbox  = new MyMessageBox("Overwrite File ?");
            msgbox.ShowDialog();
        }
    }
