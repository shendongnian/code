    private void BtnSignUp_Click(object sender, EventArgs e)
    {
		// This performs a case sensitive match on the login name, you'll need to change it if you want to ignore case
        DriverAcount existingAccount = context.DriverAcounts.FirstOrDefault(d => d.Login == TxBoxNewUserName.Text);
        if (existingAccount != null)
        {
                MessageBox.Show("This username already exists, please choose another one.");
        }
        else
        {
                if (TxtBoxPASS1.Text == TxBoxPass.Text)
                {
                        Ac.Login = TxBoxNewUserName.Text;
                        Ac.Password = TxtBoxPASS1.Text;
                        context.DriverAcounts.Add(Ac);
                	
                        // Only need to call this if you've made changes, so I've moved it here
                        context.SaveChanges();
                	
                        MessageBox.Show("The account was created successfully");
                }
                else
                {
                        MessageBox.Show("The two passwords didn't match each other.");
                }
        }
        TxBoxNewUserName.Text = "";
        TxtBoxPASS1.Text = "";
        TxBoxPass.Text = "";
    }
