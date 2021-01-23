    string insertString = string.Format(CultureInfo.InvariantCulture, "INSERT INTO tb_reg VALUES ('{0}', '{1}', '{2}', {3})", idCard, name, dateBirth, blood_type); 
    OleDbCommand cmd = new OleDbCommand(insertString, new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Data/db_klinik.mdb"));
    cmd.Connection.Open();
    int numberAdded = cmd.ExecuteNonQuery();
    if (numberAdded < 1)
    {
         //do something, the data was not added
    }
    else
    {
         //be happy :)
    }
    cmd.Connection.Close();  
