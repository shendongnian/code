    bool result=false;
    SqlCommand scCommand = new SqlCommand("usp_CheckEmailMobile", sqlCon);
    scCommand.CommandType = CommandType.StoredProcedure;
    scCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = txtName.Text;
    scCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = txtEmailAddress.Text;
    scCommand.Parameters.Add("@Password ", SqlDbType.NVarChar, 50).Value = txtPassword.Text;
    scCommand.Parameters.Add("@CountryCode", SqlDbType.VarChar.50).Value =ddlCountryCode.SelectedText;
    scCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = txtMobileNumber.Text;
    scCommand.Parameters.Add("@Result ", SqlDbType.Bit).Direction = ParameterDirection.Output;
    try
    {
        if (scCommand.Connection.State == ConnectionState.Closed)
        {
            scCommand.Connection.Open();
        }
        scCommand.ExecuteNonQuery();
        result = Convert.ToBoolean(scCommand.Parameters["@Result"].Value);
        
    
    }
    catch (Exception)
    {
    
    }
    finally
    {                
        scCommand.Connection.Close();
        Response.Write(result); 
    }
