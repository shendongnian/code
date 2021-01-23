    int modCounter = 0;
    foreach (SPListItem oListItem in listItemCollection) 
    { 
        modCounter += 1;
        awardYear = oListItem["Year"].ToString(); 
        awardCategory = oListItem["Category"].ToString(); 
        awardOrganiser = oListItem["Organiser"].ToString(); 
        if(modCounter % 2 == 0) // If modCounter is divisible by 2 (ie even)
        {
             // Add information that goes in first column
        }
        else
        {
             // Add information that goes in second column
        }
    } 
