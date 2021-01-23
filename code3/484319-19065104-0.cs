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
