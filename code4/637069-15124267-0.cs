        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                if (radioButton1.Checked)
                {
                    timerEnabled = 1;
                }
                //update the settings to the database table 
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "update Admin_Settings set Difficulty='" + comboBox3.Text + "'," + "NoOfQuestions='" + comboBox4.Text + "'," + "NoOfChoices='" + comboBox5.Text + "'," +
                    "Subject='" + comboBox8.Text + "'," + "Timer='" + comboBox2.Text + "," + "TimerEnabled=" + timerEnabled + "," + "TimerType='" + comboBox1.Text + "'";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
                MessageBox.Show("Settings updated");
            }
        }
        
