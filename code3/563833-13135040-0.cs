    void  CreateImage(string id)
    {
        // Connectoin string is taken from web.config file.
        SqlConnection _con = new SqlConnection(
          System.Configuration.ConfigurationSettings.AppSettings["DB"]);
            
        try
        {
            _con.Open();
            SqlCommand _cmd = _con.CreateCommand();
            _cmd.CommandText = "select logo from" + 
                               " pub_info where pub_id='" + 
                               id + "'";
            byte[] _buf = (byte[])_cmd.ExecuteScalar();
            
            // This is optional
            Response.ContentType = "image/gif";
            
            //stream it back in the HTTP response
            Response.BinaryWrite(_buf);
                    
                    
        }
        catch
        {}
        finally
        {
            _con.Close();
                    
        }
    }
