     SqlCommand cmd = new SqlCommand("Select uname, pswd from [Login] where uname =@uname and pswd =@ps", conn);
            cmd.Parameters.Add(new SqlParameter("@uname", "db username here"));
            cmd.Parameters.Add(new SqlParameter("@ps", "db pasword here"));            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) 
            {
                 //MessageBox.Show( "logged in!" );
                Home newhome = new Home();
                newhome.Show();
    
                this.Hide();
    
            }
            else
            {
                MessageBox.Show( "Incorrect credentials!" );
            } 
                
        
