        protected void Page_Init(object sender, EventArgs e)
        {
            CreateButtons();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Close", "javascript:OpenPopUp1();", true);
            if (Session["filter"] == DropDownList1.SelectedValue)
            {
            }
            else
            {
                if (Session["filter"] == "")
                {
                    Session["filter"] = DropDownList1.SelectedValue + ":";
                }
                else
                {
                    Session["filter"] = DropDownList1.SelectedValue + ":" + Session["filter"];
                }
            }
            DropDownList1.Items.RemoveAt(DropDownList1.SelectedIndex);
            CreateButtons();
        }
        private void CreateButtons()
        {
            PlaceHolder1.Controls.Clear();
            if (Session["filter"] != null)
            {
                string asd = Session["filter"].ToString();
                string[] split = asd.Split(':');
                for (int i = 0; i < split.Count(); i++)
                {
                    string filter = split[i].ToString();
                    Button button = new Button();
                    button.Text = split[i].ToString();
                    button.ID = split[i].ToString();
                    button.Attributes.Add("onclick", "remove(" + split[i].ToString() + ")");
                    button.Click += new System.EventHandler(button_Click);
                    PlaceHolder1.Controls.Add(button);
                }
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            //do something...
            Response.Write("hello");
        }
