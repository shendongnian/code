         if(radio.checked) 
         {
          try 
            { 
             connect.Open();
             MessageBox.Show("Opened");
             OleDbCommand command = new OleDbCommand();
             command.Connection = connect;
             command.CommandText = "Select * from Categories";
             
             OleDbDataAdapter db = new OleDbDataAdapter();
             DataSet ds = new DataSet();
             db.SelectCommand = command;
             db.Fill(ds);
             for(int i=0;i<ds.Tables[0].Rows.Count;i++)
             {
               cmbDisplay.Items.Add(ds.Tables[0].Rows[i][0].ToString());      
              }
            cmDisplay.DataBind();
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
