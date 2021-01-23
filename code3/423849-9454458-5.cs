    DataTable dt = new DataTable(); //Go get the data from your source here
     SqlConnection conn = new SqlConnection("....");
     conn.Open();
     SqlCommand cmd = new SqlCommand("dbo.BulkCopyData",conn)
     cmd.Parameters.Add( new SqlParameter("SourceData", SqlDbType.Structured){ TypeName = "dbo.MyCustomTable ", Value = dt});
     cmd.Parameters[0].
     cmd.ExecuteNonQuery();
