        if( orderedSlots[index].Month != temp.AddMonths(1).Month |
            orderedSlots[index].Year  != temp.AddMonths(1).Year) |
            orderedSlots[index].DayOfWeek != temp.DayOfWeek      |
            orderedSlots[index].GetWeekOfMonth != temp.AddMonths(1).GetWeekOfMonth){
     	    return false;
        }
     
