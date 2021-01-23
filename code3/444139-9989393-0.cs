    public partial class Form1 : Form
    {
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
            f2 = new Form2();
            f2.Owner = this;  // <-- This is the important thing
            f2.Show();
        }
    }
