    String name = "_distance";
    if (name.StartsWith("_"))
    {
        if (name.Length > 1)
        {
            name = name.Substring(1, 1).ToUpper() + (name.Length > 2 ? name.Substring(2) : "");
        }
        else
        {
            name = "";
        }
    }
