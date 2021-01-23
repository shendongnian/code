        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.InitializeListView(this.ListView2);
                this.InitializeListView(this.ListView3);
            }
        }
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitializeListView(this.ListView2);
            this.InitializeListView(this.ListView3);
        }
        protected void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitializeListView(this.ListView3);
        }
        private void InitializeListView(ListView listView)
        {
            listView.SelectedIndex = -1;
            listView.EditIndex = -1;
            listView.DataBind();
            listView.Visible = listView.Items.Count > 0;
        }
