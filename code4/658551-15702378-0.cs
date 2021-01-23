    SqlDataAdapter Adabter = new SqlDataAdapter();
     Adabter.InsertCommand = new SqlCommand("INSERT INTO devis values(@idProposition, @identreprise), Tools.GetConnection());
    
     Adabter.InsertCommand.Parameters.Add("@idproposition",SqlDbType.Int).Value = yorID;
     Adabter.InsertCommand.Parameters.Add("@identreprise", SqlDbType.Int).Value = yorID;
    
     Tools.OpenConnection();
     int result = Adabter.InsertCommand.ExecuteNonQuery();
     Tools.CloseConnection();
    
    if( result  > 0 )
    {
                    MessageBox.Show("Information Added");
    }else
    {
                      MessageBox.Show("Error");
    }
     
              
             
