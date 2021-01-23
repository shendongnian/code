            TextBox tb = new TextBox();
            tb.KeyDown += new KeyEventHandler(txtEmail_KeyDown);
            // Run Checks after the enter is pressed.
            if (e.KeyCode == (Keys.Enter) || e.KeyCode == (Keys.Tab))
            {
                if (!new EmailAddressAttribute().IsValid(txtEmail.Text))
                {
                    MessageBox.Show(txtEmail.ToString() + " is not a valid Email address");
                    txtEmail.Clear();
                }
                else
                {
                    MessageBox.Show("The address: " + txtEmail + " is valid");
                    txtEmail.Clear();
                }
            }
