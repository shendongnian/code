    if(DateTime.TryParse(date, out expiryDate))
    {
        if (expiryDate > currentDate)
        {
            return true;
        }
        else { return false; }
    }
    else
    {
        Console.Write("Invalid date.");
    }
