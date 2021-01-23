    class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var f2 = new Form2();
            f2.Show(this);
        }
    }
    class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    }
