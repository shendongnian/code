    var criterias = newPropertyCriteriaCollection
    {
      new PropertyCriteria()
      { 
        Condition = CompareCondition.NotEqual, 
        Name = "MyProperty", 
        IsNull = true, 
        Type = PropertyDataType.String
      }
    };
