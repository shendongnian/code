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
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Login]", cn);
            cmd.Connection = cn;
            SqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            bool found;
            while (reader.Read())
            {
                if (txtuser.Text == (reader["Username"].ToString()) && txtpass.Text == (reader["Password"].ToString()))
                {
                    found = true;
                    break;
                }
                else
                {
                    MessageBox.Show("Incorrect credentian..!");
                }
            }
            if (found)
            {
                     //MessageBox.Show("loged in!");
                    Home newhome = new Home();
                    newhome.Show();
                    this.Hide();
            }
        }
