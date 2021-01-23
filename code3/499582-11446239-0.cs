    if (!reader.HasRows)
                    {
                        MessageBox.Show(" Can not find user!");
                        reader.Close();
                    }
                    else
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            string user = (string)reader.GetString(0);
                            string name = (string)reader.GetString(1);
                            int roll = (int)reader.GetInt32(2);
                            string phone = (string)reader.GetString(3);
                            string address = (string)reader.GetString(4);
                            string birthofdate = (string)reader.GetString(5);
                            label1.Text = "" + roll;
                            label2.Text = name;
                            label3.Text = birthofdate;
                            label4.Text = "" + phone;
                            label5.Text = address;
    
                        }
                    }
