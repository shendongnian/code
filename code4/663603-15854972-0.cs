    private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string sqlquery;
            //Put away the apostrophes and used twice double quotations for
            //the full path of the database file:
            string connection = @"Data Source=.\SQLEXPRESS;AttachDbFilename=""C:\Users\Nick\Documents\Visual Studio 2010\Projects\DebenhamsProjectOffice V.01\DebenhamsProjectOffice V.01\DebenhamsProjectOfficeDatabase.mdf"";Integrated Security=True;Connect Timeout=30;User Instance=True";
            SqlConnection cn = new SqlConnection(connection);
            
            /* Better to let the program fail than think it's open and moving on
            removed try, catch*/
            cn.Open();
    
            //Why using your TextBoxes values if you already created strings?
            //changed
            //you should also be careful users can't type something like "') in the      
            //textboxes or they may cause a SQL injection
            sqlquery = "INSERT INTO Users (Username, Password) VALUES ('" + username + "','" + password + "')";
    
            try
            {
                SqlCommand command = new SqlCommand(sqlquery, cn);
                /* unnecessary since you already built a query command.Parameters.AddWithValue("Username", username);
                command.Parameters.AddWithValue("Password", password);
                command.Parameters.Clear();   */
    
                //Missing!!
                command.ExecuteNonQuery();
                MessageBox.Show("User Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //Elegance
            txtUsername.Clear();
            txtPassword.Clear();
            cn.Close();
        }
