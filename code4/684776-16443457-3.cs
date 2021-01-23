        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string[] Sizes = Request.Form.GetValues("item-size");
                string[] Colors = Request.Form.GetValues("item-color");
                string[] Prices = Request.Form.GetValues("item-price");
            }
        }
