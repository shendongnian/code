    $ private void chkDetailsButton_Click(object sender, EventArgs e) 
    {
     if (radioButtonA.Checked)
            {
                OleDbConnection connect = db.dbConnect();
    
                try
                {
                    connect.Open();
                    MessageBox.Show("Opened");
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connect;
    
                    command.CommandText = "Select * from Categories";
                    OleDbDataReader myReader = command.ExecuteReader();
                    while (myReader.Read()) 
                    {
                        cmbDisplay.Items.Add(myReader["SeatNo"]);
                    }
       
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception in Database" + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
        }
