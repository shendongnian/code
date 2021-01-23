    protected void bindgrideview()
    {
       .....
       adapter.Fill(table);
       GridView1.DataSource = table; // <- missing
       GridView1.DataBind();
       ....
    }
