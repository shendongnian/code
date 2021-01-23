    if (type1 != type2)
    {
        TypeConverter tc1 = TypeDescriptor.GetConverter(type1);
        TypeConverter tc2 = TypeDescriptor.GetConverter(type2);
        if (tc1.CanConvertFrom(type2))
        {
            cell2 = tc1.ConvertFrom(cell2);
            type2 = type1;
        }
        else if (tc1.CanConvertTo(type2))
        { 
            cell1 = tc1.ConvertTo(cell1, type2);
            type1 = type2;
        }
        else if (tc2.CanConvertFrom(type1))
        {
            cell1 = tc2.ConvertFrom(cell1);
            type1 = type2;
        }
        else if (tc2.CanConvertTo(type1))
        { 
            cell2 = tc2.ConvertTo(cell2, type1);
            type2 = type1;
        }
        else // fallback to string comparison
        {
            cell1 = tc1.ConvertToString(cell1);        
            type1 = cell1.GetType();
            cell2 = tc2.ConvertToString(cell2);        
            type2 = cell2.GetType();
        }
        // cell1 and cell2 should be the same type now
    }
