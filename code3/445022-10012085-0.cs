    while (reader.Read())
    {
        if (reader[col] == DBNull){
            str = "";
            if(!blNullFound){            
                sRetVal.Add(str);
            }
            blNullFound = true;
        } else {
            str = reader[col].ToString(); 
        }
    }
