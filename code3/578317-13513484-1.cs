    public sealed class Student
    {
      public string Name { get; set; }
      public string RollNo { get; set; }
      public string Standard { get; set; }
      public bool IsScholarshipped { get; set; }
      public List<string> MobNumber { get; set; }
      public object this[int index]
      {
        get
        {
          // Note: This may cause IndexOutOfRangeException!
          var propertyInfo = this.GetType().GetProperties()[index];
          return propertyInfo != null ? propertyInfo.GetValue(this, null) : null;
        }
      }
      public object this[string key]
      {
        get
        {
          var propertyInfo = this.GetType().GetProperties().First(x => x.Name == key);
          return propertyInfo != null ? propertyInfo.GetValue(this, null) : null;
        }
      }
    }
