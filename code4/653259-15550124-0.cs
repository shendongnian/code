    DataTable dt = Session["DT"]  as DataTable;
    if(dt==null)
    {
       dt = new DataTable(); 
       Session["DT"]=dt;//store it for next round trip
    }
    //rest of your code code to add a new row...
  
    GridViewAllAssigments.DataSource = dt;
    GridViewAllAssigments.DataBind();
