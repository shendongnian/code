    conn.Open();
    int a, b, c;
    using(SqlCommand cmd = new SqlCommand("select top 3 pnrnumber 
    from pnrstatus1 where
     Status='waiting'", conn))
    {
    
    
    using(SqlDataAdapter da = new SqlDataAdapter(cmd)){
        DataSet ds = new DataSet();
        da.Fill(ds);
    
        if(ds.Tables.Count > 0 AND ds.Tables[0].Rows.Count = 3)
        {
          Label1.Text = ds.Tables[0].Rows[0]["pnrnumber"].ToString();
          Label2.Text = ds.Tables[0].Rows[1]["pnrnumber"].ToString(); 
          Label3.Text = ds.Tables[0].Rows[2]["pnrnumber"].ToString();  
        }
      }
    }
