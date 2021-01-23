    public Form1()
    {
        InitializeComponent();
        this.button1.Click += delegate { ShowMessageBoxFromForm1(); };
        this.button2.Click += delegate
            {
                Form2 form2 = new Form2(ShowMessageBoxFromForm1);
                form2.ShowDialog();
            };
    }
    private void ShowMessageBoxFromForm1()
    {
        MessageBox.Show("I'm in Form1");
    }
