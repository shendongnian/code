        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            tb.Style["display"] = "none";
            uxToHide.Controls.Add(tb);
            ShowChildren(uxToHide);
        }
        public static void HideChildren(Control container)
        {
            if (container == null || container.Controls == null || container.Controls.Count == 0)
            {
                return;
            }
            foreach (Control c in container.Controls)
            {
                if (c is WebControl)
                {
                    ((WebControl)c).Style["display"] = "none";
                }
                HideChildren(c);
            }
        }
        public static void ShowChildren(Control container)
        {
            if (container == null || container.Controls == null || container.Controls.Count == 0)
            {
                return;
            }
            foreach (Control c in container.Controls)
            {
                if (c is WebControl)
                {
                    WebControl wc = (WebControl)c;
                    if (wc.Style["display"] == "none")
                    {
                        wc.Style.Remove("display");
                    }
                }
                ShowChildren(c);
            }
        }
