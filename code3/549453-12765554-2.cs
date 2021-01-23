        public partial class Form1 : Form
        {
            public static ListView lsvCustomer; 
            public Form1()
            {
                InitializeComponent();
                // this will allow access from outside the form
                lsvCustomer = this.listView1; 
            }
            private void button1_Click(object sender, EventArgs e)
            {
               frmInput f = new frmInput();
               f.ShowDialog(this);
            }
        }
