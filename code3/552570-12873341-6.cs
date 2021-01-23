    public partial class _Default : System.Web.UI.Page
    {
        public string CreateConfirmation(String action, String item)
        {
            return String.Format(@"return doConfirm('{0}', '{1}');", action, item);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("albumName", typeof(string));
            DataRow dr = null;
            dt.Columns.Add(dc);
            dr = dt.NewRow();
            dr["albumName"] = "Zen Arcade";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["albumName"] = "New Day Rising";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["albumName"] = "Candy Apple Grey";
            dt.Rows.Add(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
