    public static bool IsClearTypeEnabled
    {
        get
        {
            return SystemInformation.IsFontSmoothingEnabled && 
                 SystemInformation.FontSmoothingType == 2;
        }
