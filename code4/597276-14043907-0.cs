    foreach (var groupRows in data.AsEnumerable().GroupBy(d => d["JobDetailID"].ToString()))
    {
        if(string.IsNullOrEmpty(groupRows.Key))
            continue;
        
        // We now have each "grouping" of duplicate JobDetailIDs.
        int x = 65; // ASCII value for A
        foreach (var duplicate in groupRows)
        {
            string calcID = groupRows.Key + ((char)x++);
            duplicate["CalculatedID"] = calcID;
            //Can also do this and achieve same results.
            //duplicate["CalculatedID"] = groupRows.Key + ((char)x++);
        }
    }
