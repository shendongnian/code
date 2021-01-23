    public string ProjectReference { get; set; }
    public string ProjectNo { get; set; }
    private void Open_Project_Form_Load(object sender, EventArgs e)
    {
        projectRefrencetTextBox.Text = ProjectReference;
        projectNoTextBox.Text = ProjectReference;
    }
