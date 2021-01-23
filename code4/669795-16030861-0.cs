    public Form1()
    {
        if (new Form2().ShowDialog() != System.Windows.Forms.DialogResult.OK)
        {
            Close();
        }
        InitializeComponent();
    }
