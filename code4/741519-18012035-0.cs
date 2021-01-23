    if (Session["ExcelData"]!=null)
    {
       //Code here of binding the grid
       DataTable dt= (DataTable)Session["ExcelData"];
       GridView1.DataSource= dt;
       GridView1.DataBind();
    }
