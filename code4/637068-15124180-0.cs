    private void button1_Click(object sender, EventArgs e)
            {
                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connString))
                {
                    if (radioButton1.Checked)
                    {
                        timerEnabled = 1;
                    }
    
                    connection.Open();
    
                    //update the settings to the database table 
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "update Admin_Settings set Difficulty='" + comboBox3.Text + "'," + "NoOfQuestions='" + comboBox4.Text + "'," + "NoOfChoices='" + comboBox5.Text + "'," +
                        "Subject='" + comboBox8.Text + "'," + "Timer='" + comboBox2.Text + "," + "TimerEnabled=" + timerEnabled + "," + "TimerType='" + comboBox1.Text + "'";
    
    
                    command.ExecuteNonQuery();
    
                    MessageBox.Show("Settings updated");
                }
            }
