        public partial class Form1 : Form
        {
        
            public Image MyImage
            {
                get { return pictureBox1.Image; }
                set { 
                      //do some checks if neccessary
                      pictureBox1.Image = value; 
                    }
            }
        
            public Form1()
            {
                InitializeComponent();
            }
        }
