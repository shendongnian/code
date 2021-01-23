    object[,] result;
    object rawData = excelCell.get_Value(Missing.Value);
    if(rawData.GetType().IsArray())
    {
        result = rawData;
    }
    else
    {
        result = CreateArrayFromValue(rawData);
    }
    
    return result;
