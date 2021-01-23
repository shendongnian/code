    namespace SomeTest
    {
        public partial class Form1 : Form
        {
            Form2 fm = null;
            public Form1(Form2 fm_)
            {
                this.fm = fm_;
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Form2.mydelegate // Works.
                fm.mydelegate    // Won't work. 
            }
        }
    }
