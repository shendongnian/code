    // Make it a simple extension method for a list of object
    public static string GetCSV(this List<object> list)
    {
        StringBuilder sb = new StringBuilder();
    
        //Get the properties from the first object in the list for the headers
        PropertyInfo[] propInfos = list.First().GetType().GetProperties();
