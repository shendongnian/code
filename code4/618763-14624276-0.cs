    public static bool IsExactlyOne(object n)
    {
    bool result = false;
    try
    {
    result = Convert.ToInt32(n) == 1;
    }
    catch
    {
    }
    return result;
    }
