    public static int StringToInt(this Numbers number,Func<Numbers,string> prop)
    {
        try
        {
            return Convert.ToInt32(prop(number));
        }
        catch (Exception ex)
        {
            //catch property from prop and show it.
        }
    }
