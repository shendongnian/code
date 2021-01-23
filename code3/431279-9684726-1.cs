        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Controls.Add(CreateGadget());
        }
        private HtmlGenericControl CreateGadget()
        {
            HtmlGenericControl div_general_ac = new HtmlGenericControl("div");
            StringBuilder str = new StringBuilder();
            str.Append("<script type=\"text/javascript\"");
            str.Append(" src = '" + GadgetSrc + "'></");
            str.Append("script>");
            div_general_ac.InnerHtml = str.ToString();
            return div_general_ac;
        }
