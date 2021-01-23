    public Form1()
    {
        InitializeComponent();
        checkBox1.CheckedChanged += CheckedChanged_1;
        checkBox2.CheckedChanged += CheckedChanged_1;
        checkBox3.CheckedChanged += CheckedChanged_1;
        checkBox4.CheckedChanged += CheckedChanged_1;
        checkboxesToCount.AddRange(new CheckBox[] {checkBox1, checkBox2, checkBox3, checkBox4});
    }
    private void CheckedChanged_1(object sender, EventArgs e)
    {
        progressBar1.Value = 100 * checkboxesToCount.Count((c) => { return c.Checked; }) / checkboxesToCount.Count;
    }
