    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            holder.Controls.Clear();
            LinkButton lnkDynamic = new LinkButton();
            lnkDynamic.Click += new EventHandler(LinkClick);
            lnkDynamic.ID = "lnkDynamic123";
            lnkDynamic.Text = "lnkDynamic123";
            holder.Controls.Add(lnkDynamic);
    
            string IDValue = GetPostBackControlId(this.Page);
    
            if (IDValue == lnkDynamic.ID)
                LinkClick(lnkDynamic, new EventArgs());
        }
    }
