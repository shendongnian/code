        protected void Login_Click(object sender, EventArgs e)
            {
                if ((username.Text == "Username") & (password.text == "Password"))
                  {
                         login_form.visible = false;
                          rest_of_site.visible = true;
                   }
                else { //show some error }
            }
