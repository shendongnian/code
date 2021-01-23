    protected void Page_Load(object sender, EventArgs e)
    {
       if(Session["uniqueName"]!=null)
       {
          DataTable gridDataSource = (DataTable)Session["uniqueName"];
          
          //any custom logic you want to perform on gridDataSource
          gridView1.DataSource = gridDataSource;
          gridView.DataBind();
       }
    }
