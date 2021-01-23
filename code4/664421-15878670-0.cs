    public static string GetX(string amountUnit)
    {
        return amountUnit.ToLower().Contains("x") ? 
                            amountUnit.Split('x')[0].Trim() : 
                            "1";
    }
    public static string GetY(string amountUnit)
    {
        return amountUnit.ToLower().Contains("x") ? 
                            amountUnit.Split('x')[1].Trim() :       
                            amountUnit.Trim();
    }
