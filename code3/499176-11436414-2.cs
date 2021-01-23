    // Get the matching items
    List<TIMEGROUPINFO> matchingItems = new List<TIMEGROUPINFO>();
    foreach (TIMEGROUPINFO l1 in List1)
    {
        foreach (TIMEGROUPINFO l2 in List2)
        {
           if (l1.TimeGroupName.Equals(l2.TimeGroupName))
           {
                matchingItems.Add(l1);
                continue;
           }
        }
     }
     // Append the items from List2 which aren't already in the list:
     foreach (TIMEGROUPINFO l2 in List2)
     {
         bool exists = false;
         foreach (TIMEGROUPINFO match in matchingItems)
         {
             if (match.TimeGroupName.Equals(l2.TimeGroupName))
             {
                 // This item is already in the list.
                 exists = true;
                 break;
             }
         }
       
         if (exists = false)
             matchingItems.Add(l2);
     }
    
