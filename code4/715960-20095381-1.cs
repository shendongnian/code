    protected void Page_Load(object sender, EventArgs e)
        {           
           btnExcel_Click +=................
            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        protected void BindGridview()
        {
            gvdetails.DataSourceID = "dsdetails";      
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvdetails.AllowPaging = false;
            BindGridview();
            //Change the Header Row back to white color
            gvdetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < gvdetails.HeaderRow.Cells.Count; i++)
            {
                gvdetails.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            }
            gvdetails.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
    }
