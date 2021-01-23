    OleDbConnection connect = new OleDbConnection();
    connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Data.accdb;Persist Security Info=False;";
    connect.Open();
    OleDbCommand command = new OleDbCommand();
    command.CommandText = "SELECT AmountFrom, AmountTo, DiscPer FROM Discounts";
    command.Connection = connect;
    OleDbReader reader = command.ExecuteReader();
    while(reader.Read())
    {   
        int from = int.Parse(reader['AmountFrom'].toString());
        int to = int.Parse(reader['AmountTo'].toString());
        int discount = int.Parse(reader['DiscPer'].toString());
        if(totalPurchase >= from && totalPurchase < to) {
            MessageBox.Show("You got a discount of " + discount + "%");
        }
    }
    connect.Close();
