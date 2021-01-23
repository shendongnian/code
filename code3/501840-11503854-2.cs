    public partial class Form1 : Form
        {
               OpenFileDialog ofd = new OpenFileDialog();
           
            public Form1()
            {
                InitializeComponent();
                ofd.InitialDirectory = "C:\\ProgramData";
            }    
            private void button1_Click(object sender, EventArgs e)
            {                     
              DialogResult dr = ofd.ShowDialog();
              ofd.InitialDirectory = null;   
            }    
        }
