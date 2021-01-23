    string strConn = "Data Source=ORCL134; User ID=user; Password=psd;";
        
    System.Data.OracleClient.OracleConnection con = newSystem.Data.OracleClient.OracleConnection(strConn);
        con.Open();
        System.Data.OracleClient.OracleCommand Cmd = 
            new System.Data.OracleClient.OracleCommand(
                "SELECT * FROM TBLE_Name WHERE ColumnName_year= :year", con);
    //for oracle..it is :object_name and for sql it s @object_name
        Cmd.Parameters.Add(new System.Data.OracleClient.OracleParameter("year", (txtFinYear.Text).ToString()));
        System.Data.OracleClient.OracleDataAdapter da = new System.Data.OracleClient.OracleDataAdapter(Cmd);
        DataSet myDS = new DataSet();
        da.Fill(myDS);
        try
        {
            lblBatch.Text = "Batch Number is : " + Convert.ToString(myDS.Tables[0].Rows[0][19]);
            lblBatch.ForeColor = System.Drawing.Color.Green;
            lblBatch.Visible = true;
        }
        catch 
        {
            lblBatch.Text = "No Data Found for the Year : " + txtFinYear.Text;
            lblBatch.ForeColor = System.Drawing.Color.Red;
            lblBatch.Visible = true;   
        }
        da.Dispose();
        con.Close();
