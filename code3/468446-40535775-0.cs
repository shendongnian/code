    class ThisClass
    {
      public string a {get; set;}
      private string b {get; set;}
      public override bool Equals(object obj)
      {
        // If you only want to compare on a
        ThisClass that = (ThisClass)obj;
        return string.Equals(a, that.a/* optional: not case sensitive? */);
      }
      public override int GetHashCode()
      {
        return a.GetHashCode();
      }
    }
