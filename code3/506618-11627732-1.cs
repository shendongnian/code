    public static string GetImage(string value)
    {
        var str = "default image url";
        if(!string.IsNullOrEmpty(value))
        {
        if(value=="Yes")
              str = "yes image url";
        else if(value=="No")
              str = "no image url";
        }
        return str;
    }
