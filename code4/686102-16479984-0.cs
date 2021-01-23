        try
        { 
        con.Open();
        string mysql; // generate an sql insert query for the database
        mysql = "SELECT * FROM Cars WHERE Make LIKE (@p1)";
        OleDbCommand cmd = new OleDbCommand(mysql, con);
        cmd.Parameters.AddWithValue("@p1", tbMake.Text);
        OleDbDataAdapter da=new OleDbDataAdapter(cmd);
        DataSet ds=new DataSet();
        da.Fill(ds);
        gv.DataSourse=ds.Tables[0];
        gv.DataBind();
        con.Close();
        }
        catch(Exception ex)
        {
        }
        finally
        {
         con.close();
        }    
