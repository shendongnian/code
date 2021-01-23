    DataTable dtMealTemplate = new DataTable();
    dtMealTemplate.Columns.Add("MealTemplateID", Type.GetType("System.Int32")); 
    dtMealTemplate.Columns.Add("WeekNumber", Type.GetType("System.Int32")); 
    dtMealTemplate.Columns.Add("DayOfWeek", Type.GetType("System.String")); 
    foreach (GridViewRow gvr in GridView.Rows)
    { 
     drMT = dtMealTemplate.NewRow(); 
     drMT["MealTemplateID"] = gvr.Cells[0].text; 
     drMT["WeekNumber"] = gvr.Cells[1].text; 
     drMT["DayOfWeek"] = gvr.Cells[2].Text; 
     dtMealTemplate.Rows.Add(drMT); 
    } 
    
     public void InsertMealsTemplate(int iMealTemplateID, DataTable dtMealsData) 
     { 
    SqlCommand cmd = new SqlCommand(); 
    SqlDataAdapter sa = new SqlDataAdapter(cmd); 
    SqlCommandBuilder cmb = new SqlCommandBuilder(sa); 
    SqlTransaction oTrans; 
    SqlConnection oConn = new SqlConnection(GetConnectionString()); 
    DataSet ds = new DataSet(); 
    oConn.Open(); 
    cmd = oConn.CreateCommand(); 
    oTrans = oConn.BeginTransaction(); 
    cmd.Connection = oConn; 
    cmd.Transaction = oTrans; 
    cmd.CommandType = CommandType.Text; 
    cmd.CommandText = "SELECT * FROM YOURTABLENAME WHERE 1 = 1 ";
    sa = new SqlDataAdapter(cmd); 
    cmb = new SqlCommandBuilder(sa); 
    sa.MissingSchemaAction = MissingSchemaAction.AddWithKey; 
    cmd.Transaction = oTrans; 
    sa.Fill(ds, "yourtablename"); 
    DataRow drNew; 
    int x = 0; 
    foreach (DataRow dr in dtMealsData.Rows) 
    {
    if (Int32.Parse(dr["MealDetailsID"].ToString()) == 0) 
       { 
        drNew = ds.Tables[0].NewRow(); 
        drNew["MealTemplateID"] = dr["MealTemplateID"]; 
        drNew["WeekNumber"] = dr["WeekNumber"]; 
        drNew["DayOfWeek"] = dr["DayOfWeek"]; 
        ds.Tables[0].Rows.Add(drNew); 
        } 
    } 
    sa.Update(ds.Tables["yourtablename"]); 
    oTrans.Commit(); 
    oConn.Close(); 
    }
