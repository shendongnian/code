    String strConnection = "Data Source=HP\\SQLEXPRESS;database=MK;Integrated Security=true";
    //SqlConnection con = new SqlConnection(strConnection); not needed
    using (SqlConnection sqlConn = new SqlConnection(strConnection))
    {
          using (SqlCommand cmd = new SqlCommand(sqlConn))
          {
                int rowIndex = 1; //row index to update?
                var number = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());  //assuming Cells[0] holds number
                var name = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();                 //as above
                var id = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[3].Value.ToString());      //get id
                //your old command text was completly wrong
                cmd.CommandText = @"UPDATE tble SET  name = @name, number = @number where id =  @id"; //id and @id is key for row to update
                cmd.Parameters.Add("@name", name);
                cmd.Parameters.Add("@number", number);
                cmd.Parameters.Add("@id", id);
                
                sqlConn.Open();
    
                cmd.ExecuteNonQuery();
          }
    
    }
