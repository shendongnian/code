    protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(hdnUser.Value))
            {
                hdnRun.Value = "false";
                lblSayHello.Text = String.Format(@"Hello, {0}", hdnUser.Value);
            }
        }
