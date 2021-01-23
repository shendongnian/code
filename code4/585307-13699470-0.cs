    protected void Populate_Ddl(DropDownList ddl, string command, string valueName, string keyName)
        {
        //  Init()
        //  ------
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        SqlCommand cmd = null;
        //  
        ddl.Items.Clear();
    
        try
        {
            //  Conn
            //  ----
            conn = new      SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            conn.Open();
    
            //  Cmd
            //  ---
            cmd = new SqlCommand(command, conn);
            cmd.CommandType = CommandType.StoredProcedure;
    
    
            //  Execute
            //  -------
            rdr = cmd.ExecuteReader();
    
            //  Row(s)?
            //  -------
            if (rdr.HasRows)
            {
                //  Read
                //  ----
                while (rdr.Read())
                {
                    //  Populate
                    //  --------
                    ddl.Items.Add(
                        new ListItem(
                            rdr[keyName].ToString(),
                            rdr[valueName].ToString()));
                }
    
                //  Blank
                //  -----
                ddl.Items.Insert(0, String.Empty);
            }
    
            //  Clean up / Close down
            //  ---------------------
            cmd.Dispose();
            rdr.Dispose();
            rdr.Close();
            conn.Dispose();
            conn.Close();
    
        }
        catch (SqlException ex)
        {
            //  Throw Sql Exception 
            //  -------------------
            throw ex;
        }
        finally
        {
            //  Clean up / Close down
            //  ---------------------
            if (cmd != null)
            {
                cmd.Dispose();
            }
            if ((rdr != null) && (!rdr.IsClosed))
            {
                rdr.Dispose();
                rdr.Close();
            }
            if ((conn != null) && (conn.State != ConnectionState.Closed))
            {
                conn.Dispose();
                conn.Close();
            }
        }
    }
