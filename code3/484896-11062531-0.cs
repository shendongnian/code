    protected void BtnCmpApproval_Click(object sender, EventArgs e)
        {
        SqlConnection SqlCon = new SqlConnection(GetConnectionString());
        string query = "INSERT INTO Company_Info2 VALUES (@lblCmpUserName,@txtCmpName,
        @txtRegCountry,@txtCmpRegNo,@txtCmpEstdate,@txtCmpAddress,@ddlAddrIn)";
        try
        {
         SqlCon.Open();
         SqlCommand cmd = new SqlCommand(query, SqlCon);
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.AddWithValue("@lblCmpUserName", lblCmpUserName.Text);
         cmd.Parameters.AddWithValue("@txtCmpName", txtCmpName.Text);
         cmd.Parameters.AddWithValue("@txtRegCountry", txtRegCountry.Text);
         cmd.Parameters.AddWithValue("@txtCmpRegNo", txtCmpRegNo.Text);
         cmd.Parameters.AddWithValue("@txtCmpEstdate", txtCmpEstdate.Text);
         cmd.Parameters.AddWithValue("@Cmp_DocPath", AFU1.FileName);
    
         cmd.Parameters.AddWithValue("@txtCmpAddress", txtCmpAddress.Text);
         cmd.Parameters.AddWithValue("@ddlAddrIn", ddlAddrIn.SelectedItem.Text);
         cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
         throw new Exception(ex.Message);
      }
      finally
      { 
               SqlCon.Close();
      }
      }
