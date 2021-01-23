    DateTime[] orderedSlots = slots.OrderBy( t => t).ToArray<DateTime>();
    
    DateTime temp = orderedSlots[0];
    
    for(index = 1; index < orderedSlots.Count; index++)
    {
       if( orderedSlots[index].Month != temp.AddMonths(1).Month){
    	return false;
        }
        temp =  orderedSlots[index];
    
    
    }
    
    return true;
    
