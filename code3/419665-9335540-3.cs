    public partial class Default4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (DataTable Dt = new DataTable())
                {
                    using (DataColumn Dc = new DataColumn("Name"))
                    {
                        Dt.Columns.Add(Dc);
    
                        DataRow dr = Dt.NewRow();
                        dr["name"] = "1";
                        Dt.Rows.Add(dr);
    
                        dr = Dt.NewRow();
                        dr["name"] = "2";
                        Dt.Rows.Add(dr);
    
                        grd.DataSource = Dt;
                        grd.DataBind();
                    }
                }
            }
    
        }
    }
