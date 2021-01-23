    try
    {
        string query = "INSERT INTO User_Info2 VALUES (@UserName,@Cmp_Name,@Commercial_RegNo,@Comm_Country,@Cmp_EstablishDate,@Cmp_DocPath, @txtCmpAddress,@ddlAddrIn)";
        using (SqlConnection SqlCon = new SqlConnection(GetConnectionString()))
        {
            SqlCon.Open();
            using (SqlCommand cmd = new SqlCommand(query, SqlCon))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", lblCmpUserName.Text);
                cmd.Parameters.AddWithValue("@Cmp_Name", txtCmpName.Text);
                cmd.Parameters.AddWithValue("@Commercial_RegNo", txtRegCountry.Text);
                cmd.Parameters.AddWithValue("@Comm_Country", txtCmpRegNo.Text);
                cmd.Parameters.AddWithValue("@Cmp_EstablishDate", txtCmpEstdate.Text);
                cmd.Parameters.AddWithValue("@Cmp_DocPath", AFU1.FileName);
                cmd.Parameters.AddWithValue("@txtCmpAddress", txtCmpAddress.Text);
                cmd.Parameters.AddWithValue("@ddlAddrIn", ddlAddrIn.SelectedItem.Text);
                cmd.ExecuteNonQuery();
            }
    
        }
    
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
