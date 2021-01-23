    public enum FieldIndex
    {
    WorkOrder=0
    ,
    Description // only have to specify explicit value for the first item in the enum
    , /// ....
    ,
    MAX /// useful for getting the maximum enum integer value
    }
    for(var i=0;i<FieldIndex.MAX;i++)
    {
      var fieldName = ((FieldIndex)i).ToString(); /// get string enum name
      var value = row[i];
      
      // use reflection to find the property/field FIELDNAME, and set it's value to VALUE.
    }
