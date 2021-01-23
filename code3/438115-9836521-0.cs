      protected void show_Click(object sender, EventArgs e)
        {               
            Response.Write((Session["chb"] as CheckBox).Text);
        }
        protected void add_Click(object sender, EventArgs e)
        {
            CheckBox chb = new CheckBox();
            chb.ID = "chb";
            chb.Text = "chb";
            content.Controls.Add(chb);
            Session["chb"] = chb;
        }
