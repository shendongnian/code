    sqlString.Clear();
    sqlString.Append("INSERT INTO districts_has_stores (district_id, store_id) VALUES (");
    foreach(District item in Districts)
    {
        sqlString.Append(item.ID.ToString);
        sqlString.Append(", ")
        sqlString.Append(x.ToString()); 
        sqlString.Append("),"); 
    }
    sqlString.Length--;
    sqlCommand.CommandText = sqlString.ToString()
