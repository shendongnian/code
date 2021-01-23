    int categoryId = 0;
    
    if(Request["CategoryID"]!=null)
    {
    categoryID=Convert.ToInt32(Request["CategoryID"]);
    SqlConnection ConnObject = new SqlConnection("ConnString of your SQL Provider"); 
    SqlCommand cmd = new SqlCommand("select some thing from your table where category_ID=@catID",ConnObject); 
    cmd.Parameters.AddWithValue("@catID", categoryId); 
    SqlDatareadr dr= cmd.ExecuteReader();
    while(dr.read())
    {
    // use the returned values from DB 
    }
    }
    else
    {
     
    //category not exist
    }
