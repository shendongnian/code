    if (ver == "update")
            {
                if (RemoteFileExists(dlUrl) == true)
                {
                   myForm.Opacity = 100;
                   ...
    
                }
                else
                    MessageBox.Show("An error occurred. Please try later.");
            }
            else if (ver == "newest")
            {
                MessageBox.Show("You are currently using the newest version.");
                this.Close();
            }
            else
            {
                this.Close();
            }
