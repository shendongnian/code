		protected void Page_Load(object sender, EventArgs e)
        {
            litTest.Text = RenderUserControlAsString("WebUserControl1.ascx");
        }
        private string RenderUserControlAsString(string path)
        {
            Page page = new Page();
            UserControl control = (UserControl)page.LoadControl(path);
            //add the control to the page
            page.Controls.Add(control);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(page, sw, true);
            //return the rendered markup of the page, which only has our single user control
            return sw.ToString();
        }
