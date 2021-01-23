        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string[] Sizes = Request.Form.GetValues("size");
                string[] Colors = Request.Form.GetValues("color");
                string[] Prices = Request.Form.GetValues("price");
            }
        }
