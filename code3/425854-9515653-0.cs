        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += new EventHandler(test_PreRender);
        }
        void test_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptWishlist.DataSource = new int[] { 1, 2, 3, 4 };
                rptWishlist.DataBind();
            }
        }
        protected void rptWishlist_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            //Command Code Here
        }
        protected void rptWishlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var i = (int) e.Item.DataItem;
            var ddl = (DropDownList)e.Item.FindControl("ddlSize");
            for(int j=1; j<=i;j++)
            {
                ddl.Items.Add(new ListItem(){Text = j.ToString()});
            }
        }
              
        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("changed");
        }
