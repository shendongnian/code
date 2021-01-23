        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Session"] != null)
                {
                    ListItemCollection hodnotyState = (ListItemCollection)Session["Session"];
                    foreach (ListItem i in hodnotyState)
                    {
                        ListBox1.Items.Add(i);
                    }
                    Session.Clear();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ListItem newItem = new ListItem("123456", "Jan Novak");
            ListBox1.Items.Add(new ListItem(newItem.Text + newItem.Value, newItem.Value));
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            ListItemCollection kolekce = new ListItemCollection();
            foreach (ListItem i in ListBox1.Items)
            {
                kolekce.Add(i);
            }
            Session["Session"] = kolekce;
            Response.Redirect("page2.aspx");
        }
    }
