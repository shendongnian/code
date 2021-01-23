    temp = sender as CustomChecks;
    if (!ResponseMSQ.ContainsKey(QNo)) 
    {                             
        // First time, add an empty list
        ResponseMSQ.Add(QNo, new List<ButtonBase>());
    } 
    // At this point you're guaranteed there's something in the dictionary
    // for your QNo, even if it's just an empty list.                                    
    if (!ResponseMSQ[QNo].Any(x => x.Text.Equals(optionText)))
    {
        // If the checkbox isn't already in the list, then add it
        ResponseMSQ[QNo].Add(temp); 
    }
