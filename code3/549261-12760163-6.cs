Regex rg = new Regex("^" + txtUserName.Text);
 
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))// && !txtUserName.Focus())// && intFlag.Equals(0))
            {
                if (txtUserName.Text.Length > 0)
                {
                    if (txtUserName.Focused)
                    {
                        Regex rg = new Regex(txtUserName.Text, RegexOptions.IgnoreCase);
                        for (int i = 0; i < txtUserName.AutoCompleteCustomSource.Count; i++)
                        {
                            if (rg.IsMatch(txtUserName.AutoCompleteCustomSource[i]))
                            {
                                txtUserName.Text = txtUserName.AutoCompleteCustomSource[i];
                                txtPassword.Focus();
                                return;
                            }
                        }
                    }
                    if (txtPassword.Text.Length > 0)
                    {
                        btnLogin_Click(null, null);  //login
                    }
                    else
                    {
                        //MessageBox.Show("Please Give a Password");
                        txtPassword.Focus();
                    }
                }
                else
                {
                    //MessageBox.Show("Please Give a username");
                    txtUserName.Focus();
                }
            }
            //if (txtPassword.ContainsFocus)
            //{
            //    btnLogin_Click(sender, e);  //login
            //}
            //else
            //{
            //    this.txtPassword.Focus();
            //}
        }
