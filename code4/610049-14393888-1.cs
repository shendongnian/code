    1.Just check with Breakpoints if it works well,
    2.Does your Sql query working in sql server ? check that it may circle it out.
    3.Check your wildcard "%like%",this may have issues.
     void somewhereelse()
    {
      string qry = "select Housemcode,Name, HP,Rateperhour ,Resource_H_Code FROM House_Machinery    where Housemcode like '" + sSearch + "'";
      filldetails(qry);
    }
    
    protected void filldetails(string someqry)
    {
      Sqlconnection conn = new SqlConnection("Connectionstring");      
      Datatable dt = new Datatable();
      try
       { 
        conn.Open();
        SqlDataAdapter dap = new SqlDataAdapter(someqry,conn);
        dap.fill(dt);
        if(dt.rows.count >0)
          {
           txtItemName.Text = dt.rows.[0]["Name"].ToString();
           txtrate.Text = dt.rows.[0]["HP"].ToString();
           txtrate.Text = dt.rows.[0]["Rateperhour"].ToString();
          }
      
       }
     catch
       {
         throw;
       }
     finally
       {
         if(conn!= null)
          {
            conn.close();
           }
       }
