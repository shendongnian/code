    protected void Page_Load(object sender, EventArgs e)    
        {    
            if (!IsPostBack)    
            {    
             DataTable dt1 = new DataTable();
             DataTable dt = frmbal.GetAllForum();
             for (int i = 0; i < dt.Columns.Count;i++ )
             dt1.Columns.Add(dt.Columns[i].Caption );
      // dt1.Rows.Clear();
             DataRow []dr=dt.Select("intParentThreadID="+ Request.QueryString["id"]);
             foreach (DataRow dr in dt.Rows) {
             dt1.Rows.Add(dr.ItemArray);
            } 
             dt1.AcceptChanges();
             DataList1.DataSource =dt1;
             DataList1.DataBind();
     
            }    
        }
