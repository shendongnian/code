    public static void GetImage(string value)
    {
        if(!string.IsNullOrEmpty(value))
        {
        if(value=="Yes")
              return "yes image url";
        else if(value=="No")
              return "no image url";
        }
    }
