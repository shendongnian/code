    string sqlText = "SELECT * FROM tbl_Users WHERE userActive = 1"; 
    if (!String.Empty.Equals(tboxInputUsers.Text)) 
    { 
        // It's important to add an open parenthesis here to get a correct logic
        // All activeusers with names like words
        sqlText += " AND ("; 
        string[] words = tboxInputUsers.Text.Split(' '); 
        string id = "id"; 
 
        foreach (string word in words) 
        { 
            id += "a"; 
            sqlText += String.Format(" (userUsername LIKE @{0} OR " + 
                                       "userName LIKE @{0} OR " + 
                                       "userSurname LIKE @{0}) OR ", id); 
            command.Parameters.AddWithValue(String.Format("@{0}", id), word); 
        } 
        // We are sure that there is at least one word, so we can  remove the excess OR and close
        // the opening parenthesis following the AND
        sqlText = sqlText(0, sqlText.Length - 4);
        sqlText += ")";
    }
    command.CommandText = sqlText;
