    if(totalPurchase>=200 && totalPurchase<700)
    {
        OleDbConnection connect = new OleDbConnection();
        connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Data.accdb;Persist Security Info=False;";
        connect.Open();
    
        OleDbCommand command = new OleDbCommand();
        command.CommandText = "SELECT DiscPer FROM Discounts WHERE Amount BETWEEN 200 AND 700";
        command.Connection = connect;
    
        object result = command.ExecuteScalar();
    
        int discount = int.Parse(result.ToString());
        MessageBox.Show("You got a discount of " + discount + "%");
        connect.Close();
    }
