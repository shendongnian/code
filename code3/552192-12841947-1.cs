    protected void Button1_Click(object sender, EventArgs e)
    {
        OdbcConnection conn = new OdbcConnection();
        conn.ConnectionString = "Data Source=.\SQLEXPRESS;
                           AttachDbFilename=|DataDirectory|\VCtemps.mdf;Integrated 
                           Security=True;Connect Timeout=30;User Instance=True";
        OdbcCommand cmd = new OdbcCommand();
        string CompName = txtCompName.Text;
        string BusinessType = DropDownList1.Text;
        string Pword = txtPassword.Text;
        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "insert into company (CompName, BusinessType, Pword) 
                    values('"+ CompName + "','"+ BusinessType + "','" + Pword + "')";
        cmd.ExecuteNonQuery();
        conn.Close();
        txtCompName.Text = "";
        txtPassword.Text = "";
        DropDownList1.Text = "";
    }
