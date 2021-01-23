    errorInt = int.MinValue;
    csv.Split(',').Select(item =>
    {
        int parsed;
        if (int.TryParse(item, out parsed))
        {
            return parsed;
        }
        else
        {
            return errorInt;
        }
    }).Where(val => val != errorInt).ToList();
