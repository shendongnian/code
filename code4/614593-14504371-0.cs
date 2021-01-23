           string username = string.Empty;
           Model_DB_Employee emp = new Model_DB_Employee();
           using(Login login = new Login())
           {      
                 if(DialogResult.OK == login.ShowDialog())
                  username = login.returnUsername();
           } 
           if(username == string.Empty)
           {
                MessageBox.Show("Username required");
                return;
           }
