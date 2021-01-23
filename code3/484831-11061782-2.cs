        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["count"] = 0;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            var s = Enumerable.Range(1, 10);
            foreach (var item in s)
            {
                var b = new Button();
                b.Text = "My Button " + item.ToString();
                b.Click += new EventHandler(buttonHandler);
                this.myPanel.Controls.Add(b);
            }
        }
        void buttonHandler(object sender, EventArgs e)
        {
            // update here your control
            var b = sender as Button;
            b.BackColor = Color.Red;
            HowManyClicked();
        }
        private void HowManyClicked()
        {
            var c = (int)this.ViewState["count"];
            c++;
            this.ViewState["count"] = c;
            this.lblMessage2.Text = "Clicked controls: " + this.ViewState["count"].ToString();
        }
