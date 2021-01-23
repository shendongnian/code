    SqlCommand scCommand = new SqlCommand("usp_CheckEmailMobile", sqlCon);
    scCommand.CommandType = CommandType.StoredProcedure;
    scCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = txtName.Text;
    scCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = txtEmailAddress.Text;
    scCommand.Parameters.Add("@Password ", SqlDbType.NVarChar, 50).Value = txtPassword.Text;
    scCommand.Parameters.Add("@CountryCode", SqlDbType.Int).Value = Convert.ToInt32(ddlCountryCode.SelectedValue);
    scCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = txtMobileNumber.Text;            
    scCommand.Parameters.Add("@pintServiceID", SqlDbType.Int).Direction = ParameterDirection.Output;
    scCommand.Parameters.Add("@Result ", SqlDbType.Bit).Direction = ParameterDirection.Output;
    try
    {
        if (scCommand.Connection.State == ConnectionState.Closed)
        {
            scCommand.Connection.Open();
        }
        scCommand.ExecuteNonQuery();
        bool result = Convert.ToBoolean(scCommand.Parameters["@Result"].Value);
        Response.Write(result); 
    
    }
    catch (Exception)
    {
    
    }
    finally
    {                
        scCommand.Connection.Close();
    }
