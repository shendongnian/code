    public sealed class Student
    {
      public string Name { get; set; }
      public string RollNo { get; set; }
      public string Standard { get; set; }
      public bool IsScholarshipped { get; set; }
      public List<string> MobNumber { get; set; }
      public object this[int index]
      {
        get { return this.GetProperty_(index); }
      }
      public object this[string key]
      {
        get { return this.GetProperty_(key); }
      }
      private object GetProperty_(string key)
      {
        switch (key)
        {
          case "Name": return this.Name;
          case "RollNo": return this.RollNo;
          case "Standard": return this.Standard;
          case "IsScholarshipped": return this.IsScholarshipped;
          case "MobNumber": return this.MobNumber;
          default: throw new ArgumentException(key);
        }
      }
      private object GetProperty_(int index)
      {
        switch (index)
        {
          case 0: return this.Name;
          case 1: return this.RollNo;
          case 3: return this.Standard;
          case 4: return this.IsScholarshipped;
          case 5: return this.MobNumber;
          default: throw new ArgumentException(index.ToString());
        }
      }
    }
