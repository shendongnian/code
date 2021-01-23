        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            Page.PreRender += new EventHandler(Page_PreRender);
        }
        protected void Page_PreRender(object sender, EventArgs e) {
            Page.ClientScript.RegisterClientScriptInclude("MyJavascript", "MyURL");
        }
