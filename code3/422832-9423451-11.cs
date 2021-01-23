        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonRepeater.DataSource = new[] { 1, 2, 3, 4, 5 }; // however many items you want
            this.ButtonRepeater.DataBind();
        }
        protected void MyButtonHandler(Object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                string cmdName = b.CommandName;
                // logic based on cmdName
            }
        }
        protected void ButtonRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var button = e.Item.FindControl("MyButton") as Button;
            if (button != null)
            {
                var buttonNumber = e.Item.DataItem.ToString();
                button.CommandName = buttonNumber;
                button.ID = string.Format("MyButton_{0}", buttonNumber); // required to prevent event validation error
            }
        }
