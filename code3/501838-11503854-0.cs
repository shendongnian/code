    public partial class Form1 : Form
        {
               OpenFileDialog ofd = new OpenFileDialog();
           
            public Form1()
            {
                InitializeComponent();
                ofd.InitialDirectory = "C:\\ProgramData";
                ofd.RestoreDirectory = true;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {          
           
            DialogResult dr = ofd.ShowDialog();
    
            }
    
        }
