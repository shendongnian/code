    public Form1()
        {
            InitializeComponent();
            ChangeTextBoxes();
        }
        public void ChangeTextBoxes()
        {
            foreach (TextBox textBox in this.Controls)
            {
                textBox.Text = @"New Value";
            }
        }
