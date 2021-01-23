    public Form1()
    {
        InitializeComponent();
        textBox1.Enter += textBox1_Enter;
        textBox2.Enter += textBox2_Enter;
    }
    private void textBox2_Enter(object sender, EventArgs e)
    {
        textBox1.BorderStyle = BorderStyle.Fixed3D;
        textBox2.BorderStyle = BorderStyle.FixedSingle;
        textBox2.Focus();
    }
    private void textBox1_Enter(object sender, EventArgs e)
    {
        textBox2.BorderStyle = BorderStyle.Fixed3D;
        textBox1.BorderStyle = BorderStyle.FixedSingle;
        textBox1.Focus();
    }
