        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              if(!string.IsNullOrEmpty(Request.QueryString["id"]))
                 {
                    GetUserScraps(int.Parse(Request.QueryString["id"].ToString()));
                 }
            }
         }
        //Here u use id not querystring
        public void GetUserScraps(int id)
        {
            string getUserScraps = "SELECT r.uid ,r.unm,p.photo,s.uid,s.unm,s.text,s.date,s.sid FROM register as r, status as s, profile as p WHERE p.pid.s.sid AND r.email=p.email AND s.id='" + id + "'";
            dt = dbClass.ConnectDataBaseReturnDT(getUserScraps);
            if (dt.Rows.Count > 0)
            {
                GridViewUserScraps.DataSource = dt;
                GridViewUserScraps.DataBind();
            }
        }
