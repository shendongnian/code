    StringBuilder sb = new StringBuiler();
    bool isFirst = true;
    sb.Append("(");
    foreach(var prod in final_products)
    {
        if(isFirst)
            isFirst = false;
        else
            sb.Append(", ");
   
        sb.Append(prod.Id);
    }
    sb.Append(")");
    string query = "SELECT SURF FROM Products_Unique_SURF WHERE Id in "+sb.ToString();
    // execute the query
    // foreach row, decompress, deserialize etc...
