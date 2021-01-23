    var criterias = newPropertyCriteriaCollection
    {
      new PropertyCriteria()
      { 
        Condition = CompareCondition.Equal, 
        Name = "MyProperty", 
        IsNull = true, 
        Type = PropertyDataType.String
      }
    };
