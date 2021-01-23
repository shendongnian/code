    DataTable dt;
    Protected void Page_load(object sender ,EventArgs e) 
    {
         if(!Page.IsPostBack)
         {
            myGridView.DataSource=GetData();
            myGridView.DataBind();
         }
    }
   
    Private DataTable GetData()
    {
         dt = new DataTable("testingDt");
         dt.Columns.Add(New DataColumn("S.No",typeof(int)));  
         dt.Columns.Add(New DataColumn("Name",typeof(string)));
         // Add rows
         return dt;
    }
    
