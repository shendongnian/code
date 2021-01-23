    public partial class exportgridtoexcel : System.Web.UI.Page
    {
        SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }
        public void GetData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from EmpData", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            GetData();
            exporttoexcel("Report.xls", GridView1);
            GridView1 = null;
            GridView1.Dispose();
        
        }
        public void exporttoexcel(string filename,GridView gv)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=" + filename);
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm=new HtmlTextWriter(sw);
            gv.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}
