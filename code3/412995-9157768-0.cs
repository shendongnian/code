    public string FormatJs(object movieTitle)
    {
        return string.Format(
            "setSessionValue(\"video\", {0});", 
            new JavaScriptSerializer().Serialize(movieTitle)
        );
    }
