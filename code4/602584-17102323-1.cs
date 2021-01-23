                string myconnection = "datasource= localhost;port=3306;username=root;password=root;";
                MySqlConnection myconn = new MySqlConnection(myconnection);
                
                //MySqlDataAdapter mydata = new MySqlDataAdapter();
                MySqlDataReader myreader;
                
                MySqlCommand SelectCommand = new MySqlCommand("select *from student_info.student_info where username= '" + textBox1.Text +" 'and password=' " + textBox2.Text +"';",myconn );
               
               
                myconn.Open();
                 
                myreader = SelectCommand.ExecuteReader();
                int count = 0;
                if (myreader.HasRows) //returing false but i have 4 row
                {
                    while (myreader.Read()) //returing false 
                    {
                        MessageBox.Show("in button3");
                        count = count + 1;
                    }
                }
