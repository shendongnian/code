        protected void Page_Init(object sender, EventArgs e)
        {
            Button button1 = new Button();
            button1.ID = "Button1";
            button1.Text = "Submit";
            button1.Click += new EventHandler(Button_Click);
            Label label1 = new Label();
            label1.ID = "Label1";
            label1.Text = "A full page postback occurred.";
            var s1 = Builder<Product>.CreateListOfSize(15).Build();
            GridView gv1 = new GridView();
            gv1.DataSource = s1;
            createButton(gv1);
            gv1.RowCommand += new GridViewCommandEventHandler(CustomersGridView_RowCommand);
            this.myPanel.Controls.Add(button1);
            this.myPanel.Controls.Add(label1);
            this.myPanel.Controls.Add(gv1);
        }
        void createButton(GridView g)
        {
            ButtonField tea = new ButtonField();
            tea.ButtonType = ButtonType.Image;
            tea.ImageUrl = "~/checkdailyinventory.bmp";
            tea.CommandName = "buttonClicked";
            tea.HeaderText = "space";
            g.Columns.Add(tea);
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            ((Label)Page.FindControl("Label1")).Text = "Panel refreshed at " +
                DateTime.Now.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }
        public void CustomersGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "buttonClicked")
            {
                //int index = Convert.ToInt32(e.CommandArgument);
                this.lblMessage.Text = DateTime.Now.ToString();
            }
        }
