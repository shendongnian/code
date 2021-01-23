     SqlCommand cannot be serialized, so you will need to instantiate in the function.
     [WebMethod]
     public DataSet GetDataSet()
     {
     SqlCommand cmd = new SqlCommand();
     using (SqlConnection Conn = new SqlConnection(ConnString))
     {
        cmd.Connection = Conn;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            //Conn.Open();
            using (DataSet DS = new DataSet())
            {
                da.Fill(DS);
                return DS;
            }
        }
        catch (Exception ex)
        {
            return (new DataSet());
        }
        finally
        {
            if (da != null)
            {
                da.Dispose();
            }
        }
      }
    }
