    public static Dictionary<string, PropertyInfo> ColumnMapper = new Dictionary<string, PropertyInfo>
                                                                       {
                                                                           {"StatusTypeId", typeof(Defects).GetProperty("CustomerStatus*") },
                                                                           {"DefectId", typeof(Defects).GetProperty("DefectId") },
                                                                           {"Name", typeof(Defects).GetProperty("Name") }
                                                                       }; 
    * Thats the Custom Column from above.
