    public partial class MyTextBox : TextBox
    {
        public delegate void AutoCompleteDelegate();
        public event AutoCompleteDelegate AutoCompleteUsed;
        public MyTextBox()
        {
            InitializeComponent();
            this.TextChanged += MyTextBox_TextChanged;
            this.KeyDown += MyTextBox_KeyDown;
        }
        private bool keyPressed = false;
        void MyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            keyPressed = true;
        }
        void MyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!keyPressed && AutoCompleteUsed != null)
            {
                AutoCompleteUsed();
            }
            keyPressed = false;
        }
    }
