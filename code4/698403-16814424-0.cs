    string val = "23.12.1992 00:00:00";
    // Parse exactly from your input string to the native date format.
    DateTime dt = DateTime.ParseExact(val, "dd.M.yyyy hh:mm:ss", null);
    
    // Part to SqlDateTime then            
    System.Data.SqlTypes.SqlDateTime dtSql = System.Data.SqlTypes.SqlDateTime.Parse(dt.ToString("yyyy/MM/dd"));
