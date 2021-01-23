    public static string ExecuteSelect(string query)
    {
    //Example query is: SELECT entity_id FROM catalog_product_flat_1 WHERE 
    sku='itemSku';
    string statement = "";
    MySqlCommand myCommand = new MySqlCommand(query, _conn);
    MySqlDataReader myReader;
    myReader = myCommand.ExecuteReader();
    myReader.Read();
    if(!myReader.HasRows)
    {
     //set your statement variable to some generic value
     statement="abracadabra";
    }
    while(myReader.Read())
    {
    statement = myReader[0].ToString();
    }
    myReader.Close();
    return statement;
    }
    
