     try
       {
            OracleCommand oc = new OracleCommand(query, con);
            oc.CommandType = CommandType.Text;
            return  oc.ExecuteScalar().ToString();
         
        }
        catch (OracleException ex)
        {
            MessageBox.Show(ex.Message);
            return string.Empty;
        }
        }
        finally
        {
          con.Close();
          con.Dispose();
        }
