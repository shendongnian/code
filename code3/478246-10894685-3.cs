        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                lblSelectedItem.Text = Request["ddlItems"].ToString();
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<string> populate(string populateInitial)
        {
            if (populateInitial == "1")
                return (new string[] { "a", "b" }).ToList();
            else
                return (new string[] { "c", "d", "e", "f" }).ToList();
        }
