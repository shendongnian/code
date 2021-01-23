    public Form1()
    {
        InitializeComponent();
        textBox1.MouseWheel += textBox1_MouseWheel;
        panel1.KeyDown += panel1_KeyDown;
    }
    void panel1_KeyDown(object sender, KeyEventArgs e)
    {
        textBox1.Focus();
    }
    void textBox1_MouseWheel(object sender, MouseEventArgs e)
    {
        panel1.Focus();
    }
