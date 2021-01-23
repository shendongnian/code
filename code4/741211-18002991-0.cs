    public string Name { get; set;}
    private void buttonClick(object sender, EventArgs e)
    {
        Name = txtbxName.Text;
        Close();
    }
