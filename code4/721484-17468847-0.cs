        int a
        {
            get
            {
                if (ViewState["a"] == null)
                {
                    ViewState["a"] = 0;
                }
                return Convert.ToInt16(ViewState["a"]);
            }
            set
            {
                ViewState["a"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            a = 3;
        }
