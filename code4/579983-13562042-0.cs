    private static string[] firstParts; // field
    private static string[] FirstParts // property
    {
        get
        {
            if (firstParts == null)
            {
                using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("App_Data/QuestionPart1.txt")))
                    firstParts = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            return firstParts;
        }
    }
