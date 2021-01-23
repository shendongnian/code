    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Task.Factory.StartNew(() => {
    
                    Form frmSettings = new Form();
                    frmSettings.Width = 300;
                    frmSettings.Height = 200;
                    frmSettings.StartPosition = FormStartPosition.CenterParent;
    
                    frmSettings.ShowDialog();
                
                } );   
                
            }
        }
