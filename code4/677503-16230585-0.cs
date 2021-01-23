	private void btnlogin_Click(object sender, EventArgs e)
    {
        string connection = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|ResturantDB.mdf;Integrated Security=True;User Instance=True";
        SqlConnection cn = new SqlConnection(connection);
        try
        {
            cn.Open();
        }
        catch (Exception)
        {
            MessageBox.Show("Conncetion to Database faild check Connection !");
        }
        while (true)
        {
	        SqlCommand cmd = new SqlCommand("SELECT [Password] FROM [Login] WHERE [Username] = '" + txtuser.Text + "'", cn);
	        cmd.Connection = cn;
	        SqlDataReader reader = null;
	        reader = cmd.ExecuteReader();
	        
	        if (!reader.HasRows)
	        	MessageBox.Show("User does not exist. Please, try again.");
	        else
	        {
	        	//username should be unique, so only one row is possible to have
	        	reader.Read();
	        	if (txtpass.Text == (reader["Password"].ToString()))
		            {
		                //MessageBox.Show("loged in!");
		                Home newhome = new Home();
		                newhome.Show();
						
		                this.Hide();
		              	return;
		            }
	        	else
		                MessageBox.Show("Incorrect credentian..! Try again.");
	        }
        }
	}
