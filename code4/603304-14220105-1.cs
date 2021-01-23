    public String ViewUserVat(String code)
    {
        var command = CamOnlineAccess.Utilities().GetCommandSP("dbo.ViewUserVat"))
        
        try
        {
            command.Parameters.AddWithValue("@code", code);
            command.Connection.Open();
            return (String)command.ExecuteScalar();
        }
        finally
        {            
            command.Connection.Close();
            command.Dispose();
        }
    }
