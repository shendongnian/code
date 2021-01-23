    foreach (DataGridViewRow row in dataGridView1.Rows)
     {
            if(row == null || row.Cells[0].Value == null)
               continue;
            try
             {
                mysqlStatement = "INSERT INTO test1(ID, Authors,Paper, GSCitations) VALUES('" + row.Cells[0].Value + "','" + row.Cells[1].Value + "','" + row.Cells[2].Value + "','" + row.Cells[3].Value +"');";
                mySqlCommand = new MySqlCommand(mysqlStatement, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();     
             }
    
            catch(Exception excep)
            {
                MessageBox.Show(excep.ToString()); 
            }
      }
