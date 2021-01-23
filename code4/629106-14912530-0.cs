        private void button15_Click(object sender, EventArgs e)
        {
            string a = button11.Text;
            string imagePath;
            string connString = "Server=Localhost;Database=test;Uid=root;password=root;";
            using(MySqlConnection conn = new MySqlConnection(connString))
            using(MySqlCommand command = conn.CreateCommand())
            {
                command.CommandText = "Select link from testtable where ID=@id";
                command.Parameters.AddWithValue("@id", int.Parse(a));
                try
                {
                    conn.Open();
                    imagePath= (string)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                //button11.Image = ex.ToString();
                }
                button11.Image = Image.FromFile(imagePath);
            }
        } 
