    string newStudQuery = "SELECT MAX(StudentRegNo) FROM NewStudent";
    string queryResult = search(newStudQuery);
    if (!int.TryParse(queryResult, out RegNo))
    {
        RegNo = 0;
    }
    RegNo++;    
