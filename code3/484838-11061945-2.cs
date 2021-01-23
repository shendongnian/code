        protected void Page_Init(object sender, EventArgs e)
        {
            var i = new ImageButton();
            i.Click += new ImageClickEventHandler(i_Click);
            this.myPanel.Controls.Add(i);
        }
        void i_Click(object sender, ImageClickEventArgs e)
        {
            // do something
        }
