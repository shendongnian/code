    /// <summary>
    /// This holds the number and names of the subcategories that are required for each category. 
    /// </summary>
    string[] subCategories = new string[3] { "Critical Down Time", "Critical Outage", "Total Repair Time" };
    string categoryPrevious = null;
    string categoryCurrent = null;
    int subCategoryOccurences = 0;
    int rowCount = 0;
    DataRow rowFiller = null;
