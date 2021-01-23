    class someClass()
    {
      public string AStringProperty { get; set; }
      public bool IsInitiazlied 
      {
        return string.IsNullOrWhitespace(this.AStringProperty);
      }
    }
