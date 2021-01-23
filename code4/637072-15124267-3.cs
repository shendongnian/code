        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                if (radioButton1.Checked)
                {
                    timerEnabled = 1;
                }
             
               string queryString = "update Admin_Settings set Difficulty='" +      
                comboBox3.Text + "'," + "NoOfQuestions='" + comboBox4.Text + "'," + 
                "NoOfChoices='" + comboBox5.Text + "'," + "Subject='" + comboBox8.Text +  
               "'," + "Timer='" + comboBox2.Text + "," + "TimerEnabled=" + timerEnabled +  
                  "," + "TimerType='" + comboBox1.Text + "'";
              using (SqlCommand command = new SqlCommand(queryString, connection))
              {
                //update the settings to the database table 
                
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
                MessageBox.Show("Settings updated");
              }
            }
        }
        
