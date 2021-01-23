    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostback)
        {
             dt = Session["data_table"] as DataTable;
        }
    }
    
    protected void btnTextDisplay_Click(object sender, EventArgs e)
    {
         if (dt == null)
         {
              dt = new DataTable();
              DataColumn dc1 = new DataColumn("Name");
              DataColumn dc2 = new DataColumn("City");
              dt.Columns.Add(dc1);
              dt.Columns.Add(dc2);   
         }
         
         DataRow dr = dt.NewRow();
         dr[0] = txtName.Text;
         dr[1] = txtCity.Text;
         dt.Rows.Add(dr);
         gvDisplay.DataSource = dt;
         gvDisplay.DataBind();
         Session["data_table"] = dt;
    }
