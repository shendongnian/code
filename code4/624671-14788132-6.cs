    //Properties for MainForm
    public string ProjectReference { get; set; }
    public string ProjectNo { get; set; }
    
    private void openButton_Click(object sender, EventArgs e)
    {
        using(var f = new Open_Project_Form() { Owner = this })
        {
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
              projectRefrencetTextBox.Text = ProjectReference;
              projectNoTextBox.Text = ProjectNo;
            }
        }
    }
