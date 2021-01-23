    public static void Register(HttpConfiguration config)
    {
        // .....
        config.Formatters.JsonFormatter.SerializerSettings.StringEscapeHandling 
            = StringEscapeHandling.EscapeHtml;
        // .....
    }
