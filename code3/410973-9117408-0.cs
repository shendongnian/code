            litTest.Text = RenderUserControlAsString("WebUserControl1.ascx");
        }
        public Stream RenderUserControl(string path)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(RenderUserControlAsString(path)));
        }
        public string RenderUserControlAsString(string path)
        {
            System.Web.UI.Page page = new System.Web.UI.Page();
            System.Web.UI.UserControl control = (System.Web.UI.UserControl)page.LoadControl(path);
            //add the control to the page
            page.Controls.Add(control);
            StringWriter sw = new StringWriter();
            HttpContext.Current.Server.Execute(page, sw, true);
            //return the rendered markup of the page, which only has our single user control
            return sw.ToString();
        }
