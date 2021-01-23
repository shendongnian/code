    public Form1()
        {
            InitializeComponent();
            ChangeTextBoxes();
        }
    public void ChangeTextBoxes()
        {
            foreach (var c in this.Controls.OfType<TextBox>())
            {
                c.Text = @"New Value";
            }
        }
