        protected void Page_Load(object sender, EventArgs e)
        {
            NameLabel.Visible = false;
            NameBox.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            NameLabel.Visible = true;
            NameBox.Visible = true;
        }
