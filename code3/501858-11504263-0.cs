    string conjuction = " ";
    if (!string.IsNullOrEmpty(disCode)) 
    { 
                 selectQuery.Append(conjunction);
                 selectQuery.Append("DISCOUNTCode = '" + disCode + "'"); 
                 conjuction = " OR ";              
    } 
 
    if (!string.IsNullOrEmpty(disName)) 
    { 
                 selectQuery.Append(conjunction);
                 selectQuery.Append("DISCOUNTName = '" + disName + "'"); 
                  conjuction = " OR ";
    } 
