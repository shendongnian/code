     static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                Form2 fLogin = new Form2();
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            private void btnKlik_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        }
