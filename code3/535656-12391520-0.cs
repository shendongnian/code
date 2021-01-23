    class DataAccessLayerPerson
    {
      public FirstName
      {
        get; set;
      }
      public MiddleName
      {
        get; set;
      }
      public LastName
      {
        get; set;
      }
      public getFullName()
      {
         return FirstName + MiddleName + LastName;
      }
    }
    class BusinessLogicLayerPerson
    {
      public FirstName
      {
        get; set;
      }
      public MiddleName
      {
        get; set;
      }
      public LastName
      {
        get; set;
      }
      public FullName
      {
        get; set;
      }
    }
