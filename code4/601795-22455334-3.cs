     private void btnretrieve_Click(object sender, EventArgs e)
        {
            try
            {
                string lastname = null;
                string firstname = null;
                string age = null;
                DbManager db = new DbManager();
                bool status = db.GetUsersData(ref surname, ref firstname, ref age);
                    if (status)
                    {
                    txtlastname.Text = surname;
                    txtfirstname.Text = firstname;
                    txtAge.Text = age;       
                   }
              }
           catch
              {
               
              }
       }
