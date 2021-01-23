    class SpecialType {
      // include the fields and all attributes that you need to reference, ToString method for debugging, and any serialization you need
      public string foo { get; set; }
      public string bar { get; set; }
      public ToString() { return "SpecialType with foo '" + foo + "' and bar '" + bar + "'"; }
    }
    Dictionary<int, SpecialType> myDict = new Dictionary<int, SpecialType> {
       { 1, new SpecialType { foo = "XA1B2", bar = "XC3D4" } },
       { 2, new SpecialType { foo = "ZA1B2", bar = "ZC3D4" } },
       { 3, new SpecialType { foo = "YA1B2", bar = "YC3D4" } },
    }
