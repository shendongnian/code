    if (type1 != type2)
    {
        TypeConverter tc1 = TypeDescriptor.GetConverter(type1);
        TypeConverter tc2 = TypeDescriptor.GetConverter(type2);
        if (tc1.CanConvertFrom(type2))
        {
            cell2 = tc1.ConvertFrom(cell2);
        }
        else if (tc2.CanConvertTo(type1))
        { 
            cell2 = tc2.ConvertTo(cell2, type1);
        }
        else 
        {
            // fallback to string compare?
            cell1 = tc1.ConvertToString(cell1);        
            cell2 = tc2.ConvertToString(cell2);        
        }
        // cell1 and cell2 should be the same type now
    }
