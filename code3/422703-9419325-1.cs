    public void comboQuotationboxload()
    {
        OleDbConnection oleDbConnection1 = new System.Data.OleDb.OleDbConnection(connString);
        oleDbConnection1.Open();
        OleDbCommand oleDbCommand1 = new System.Data.OleDb.OleDbCommand("Select quotationpk ,quotationcode , amount from  quotationmastertable  where jobpk = " + cmbjobcode.SelectedValue + "", oleDbConnection1);
           
        OleDbDataReader reader = oleDbCommand1.ExecuteReader();
        if (!reader.Read())
            return;
        cmbQuotationcode.ValueMember = "quotationpk";
        cmbQuotationcode.DisplayMember = "quotationcode";
        cmbQuotationcode.DataSource = reader;
        txtamount.text = reader["amount"].ToString();
        oleDbConnection1.Close();
    }
