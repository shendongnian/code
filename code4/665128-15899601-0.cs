        protected void txt_username_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_username.Text))
            {
                if (xyz.checkusername(txt_username.Text.Trim()))
                {
                    lblStatus.Text = "UserName Already Taken";
                }
                else
                {
                    lblStatus.Text = "UserName Available";
                }
            }
        }
