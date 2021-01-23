    public static Color GetColor(String ColorName)
    {
        Type colors = typeof(System.Windows.Media.Colors);
        foreach(var prop in colors.GetProperties())
        {
            if(prop.Name == ColorName)
                return ((System.Windows.Media.Color)prop.GetValue(null, null));
        }
    
        throw new Exception("No color found");
    }
