    [Microsoft.SqlServer.Server.SqlTrigger (Name="Trigger1", Target="Table1", Event="FOR UPDATE")]
    public static void Trigger1()
    {
        SqlConnection conn = new SqlConnection("context connection=true;");
        SqlCommand cmd = new SqlCommand("select top 0 * from Table1", conn);
    
        conn.Open();
    
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
    
        if (SqlContext.TriggerContext.IsUpdatedColumn(dr.GetOrdinal("columnname")))
        {
            SqlContext.Pipe.Send("columnname was updated");
        }
        else
        {
            SqlContext.Pipe.Send("columnname was not updated");
        }
    
        dr.Close();
        conn.Close();
    } 
