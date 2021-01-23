    try
    {
        SqlConnection conn = new SqlConnection(stringconection);
    
        conn.Open();
       
        SqlCommand comando = new SqlCommand(/*my query update/delete/insert/select o execute sp*/,conn);
        comando.Parameters.Add("@parameter1","value1");
        comando.Parameters.Add("@parameter2","value2");
        comando.Parameters.Add("@parameterN","valueN");
        comando.ExecuteNonQuery();
    }
    catch(Exception ex) 
    {
       // catch exceptions here 
    }
    finally
    {
        if(comando != null)
        {
            comando.Dispose();
        }
        if(conn != null)
        {
            conn.Dispose();
        }
    }
