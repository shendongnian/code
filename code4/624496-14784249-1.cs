    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CellNo { get; set; }
    private void Form2_Load(object sender, EventArgs e)
    {
        txtFirstName.Text = FirstName;
        txtLastName.Text = LastName;
        txtCellNo.Text = CellNo;
    }
