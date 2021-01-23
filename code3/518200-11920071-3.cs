    public static string GetValue(string PropertyName)
    {
        switch (PropertyName)
        {
            case "F1":
                return Age.F1;
            case "F2":
                return Age.F2;
            case "F3":
                return Age.F3;
            case "F4":
                return Age.F4;
            default:
                return string.Empty;
        }
    }
