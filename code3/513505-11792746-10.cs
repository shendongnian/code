    protected void Page_Load(object sender, EventArgs e)
        {
            List<string> str = new List<string>{"I", "You", "They"};
            Repeater1.DataSource = str;
            Repeater1.DataBind();
        }
        protected void Repeater1_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lb = (LinkButton)e.Item.FindControl("lb");
                string str = (string) e.Item.DataItem;
                lb.Text = str;
            }
            
        }
