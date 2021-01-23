    public bool Equals(Test other) 
    {
      return (other == null) ?
         false : (Id == other.Id) && (Name == other.Name);
    }
    public override bool Equals(Object obj)
    {
      Test testObj = obj as Test;
      return testObj == null ? false : Equals(testObj);   
    }
