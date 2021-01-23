        protected void Page_Init(object sender, EventArgs e)
        {
            var s1 = Builder<Product>.CreateListOfSize(5).Build();
            var s2 = Builder<Order>.CreateListOfSize(9).Build();
            var g1 = new DataGrid { Width = new Unit("50%"), DataSource = s1 };
            var g2 = new DataGrid { Width = new Unit("50%"), DataSource = s2 };
            this.myPanel.Controls.Add(g1);
            this.myPanel.Controls.Add(g2);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }
