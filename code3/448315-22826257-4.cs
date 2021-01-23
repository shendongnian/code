          int InNumTry = 0;
        private void BtnGo_Click_1(object sender, EventArgs e)
        {
            string password;
            password = TxtIn.Text;
                switch (password)
                {
                    case " ": MessageBox.Show("Passowrd is empty.");
                        break;
                    case "MIKE": MessageBox.Show("Password is OK!");
                        FrmBOO newForm = new FrmBOO();
                        newForm.Show();
                        break;
                    default:
                        InNumTry++;
                        MessageBox.Show("Invalid Passwrod, try again!");
                        TxtIn.Text = "";
                        TxtIn.Focus();
                        break;
                }
                if (InNumTry >= 3)
                {
                    MessageBox.Show("You have tried too many times, have a good day.");
                    TxtIn.Enabled = false;
                }
            }
