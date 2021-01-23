    public Form1()
    {
        InitializeComponent();
        var hdmi = "HDMI";
        for (int i = 1; i < 15; i++)
        {
            comboBox1.Items.Add( hdmi + i);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (comboBox1.Items.Count >= 2)
            comboBox1.SelectedIndex = 2;
    }
