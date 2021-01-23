     protected void checkField(object sender, EventArgs e)
        {
            if (id.Text == "" || pass.Text == "")
            {
                logbutton.Visible = false;
            }
            else
                logbutton.Visible = true;
        }
