    DataConn theConn;
    private void frmNewForm_Load(object sender, EventArgs e)
    {
        theConn = new DataConn();
        theConn.GetData();
        txtName.Text = theConn.Name;
    }
    private void btnNext_Click(object sender, EventArgs e)
    {
        if (theConn.Increment != theConn.MaxRows - 1)
        {
            theConn.Increment++;
            theConn.NavigateRecords();
            FillTextBox();
        }
    }
