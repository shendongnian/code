    protected void Page_Load(object sender, EventArgs e)
        {
            List<Data> lstData = new List<Data>();
            for (int index = 0; index < 10; index++)
            {
                Data objData = new Data();
                objData.EstimateID = index;
                objData.VersionNo = "VersionNo" + index;
                lstData.Add(objData);
            }
    
            GridView1.DataSource = lstData;
            GridView1.DataBind();
        }
    
        public class Data
        {
            public int EstimateID { get; set; }
            public string VersionNo { get; set; }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink HyperLink1 = e.Row.FindControl("HyperLink1") as HyperLink;
                HyperLink1.NavigateUrl = "Details.aspx?EstimateID=" + e.Row.Cells[1].Text + "&VersionNo=" + e.Row.Cells[2].Text;
            }
        }
