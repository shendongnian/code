    double result;
    if (Double.TryParse(inputstring, result))
    {
        if (result >= 1.0 & result <= 30.0)
        {
            return true;
        }
    }
    else
    {
        return false;
    }
