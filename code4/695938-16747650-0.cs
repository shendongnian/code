    public partial class DynamicControl : System.Web.UI.Page
    {
        DataSet ds;
        RadioButtonList rbList;
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            //just some demo data..
            ds = new DataSet();
            ds.Tables.Add("test");
            ds.Tables[0].Columns.Add("AuthenticationModes");
            ds.Tables[0].Columns.Add("AuthenticationModeId");
            DataRow r1 = ds.Tables[0].NewRow();
            r1["AuthenticationModes"] = "windows";
            r1["AuthenticationModeId"] = "1";
            ds.Tables[0].Rows.Add(r1);
            DataRow r2 = ds.Tables[0].NewRow();
            r2["AuthenticationModes"] = "Forms";
            r2["AuthenticationModeId"] = "2";
            ds.Tables[0].Rows.Add(r2);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rbList = new RadioButtonList();
            foreach (DataRow authModeObj in ds.Tables[0].Rows)
            {
                rbList.Items.Add(new ListItem(
                    authModeObj["AuthenticationModes"].ToString(),
                       authModeObj["AuthenticationModeId"].ToString()));
            }
            plhldrAuthModes1.Controls.Add(rbList);
        }
        protected void btnAuthModeSave_Click(object sender, EventArgs e)
        {
            string authenticationModeCheckedVal = rbList.SelectedItem.Text;
        }
    }
