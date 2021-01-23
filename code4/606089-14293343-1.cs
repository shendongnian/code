    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
    
                //Method 1. center at initilization
                this.StartPosition = FormStartPosition.CenterScreen;
    
                //Method 2. The manual way
                this.StartPosition = FormStartPosition.Manual;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height)/2;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width)/2;
    
            }
        }
    }
