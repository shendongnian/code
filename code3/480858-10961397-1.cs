    SqlConnection connection = new SqlConnection("Your connection string");
    connection.Open();
    
    SqlDataAdapter dataAdapter = new SqlDataAdapter(
        "SELECT id, Name, Fruit FROM FruitPrefs",
        connection);
    DataTable dtResult1 = new DataTable();
    dataAdapter.Fill(dtResult1);
    
    dataAdapter = new SqlDataAdapter(
        "SELECT id, BoughtFrom, Date, Quantity FROM SalesRecords",
        connection);
    DataTable dtResult2 = new DataTable();
    dataAdapter.Fill(dtResult2);
    
    DataSet dsResults = new DataSet("Results");
    dsResults.Tables.Add(dtResult1);
    dsResults.Tables.Add(dtResult2);
    DataRelation relation1 = new DataRelation(
        "relation1",
        dtResult1.Columns["id"],
        dtResult2.Columns["id"]);
    dsResults.Relations.Add(relation1); 
