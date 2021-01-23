	private void button1_Click(object sender, EventArgs e)
        {
            string MyConString = "server=localhost;" +"database=sentiwornet;" + "password=zia;" +"User Id=root;";
            StreamReader reader = new StreamReader("D:\\input.txt");
            float amd=0;
            string line;
	    MySqlConnection connection = new MySqlConnection(MyConString);
	    connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader Reader;
            float pos1 = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                
                foreach (string part in parts)
                {
                    command.CommandText = "SELECT Pos_Score FROM score WHERE Word = part";
                    try
                    {
                        amd = (float)command.ExecuteScalar();
                        pos1 = amd + pos1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Reader = command.ExecuteReader();
                    
                }
            }
            MessageBox.Show("The Positive score of Sentence is="+pos1.ToString());
            reader.Close();
            connection.Close();
        }    
