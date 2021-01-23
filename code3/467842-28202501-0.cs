      // Constructor
      public OrderLine()
      {
        AddValidationRule(() => Number).Condition(() => string.IsNullOrWhitespace(Number)).Message("Please fill the product name");
      }
