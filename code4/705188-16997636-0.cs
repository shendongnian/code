    public void ProcessRequest(HttpContext context)
    {
        using (var reader = new StreamReader(context.Request.InputStream))
        {
            // This will equal to "charset = UTF-8 & param1 = val1 & param2 = val2 & param3 = val3 & param4 = val4"
            string values = reader.ReadToEnd();
        }
    }
