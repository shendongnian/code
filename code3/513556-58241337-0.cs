        protected void Page_Load(object sender, EventArgs e)
        {
            var id = "IsPageRefresh";
            if (IsPostBack && (bool)ViewState[id] != (bool)Session[id]) Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
            Session[id] = ViewState[id] = !(bool)(ViewState[id] ?? false);
            // do something
         }
