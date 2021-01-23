    MySqlConnection connection = new MySqlConnection(MyConString);
    string sQuery="Select * from Table";
    
    MySqlDataAdapter myDA = new MySqlDataAdapter(sQuery, connection);
    MySqlCommandBuilder cmb = new MySqlCommandBuilder(myDA);
    
    DataTable MyDT = new DataTable()// <- My DataTable
    myDA.Fill(MyDT);
     
    //Add new rows or delete/update existing one
    //and update the DataTable using 
    
    myDA.Update(MyDT);
