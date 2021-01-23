    interface ISomeRequestClass {
        string Header { get; set; }
        string ClassName1 { get; set; }
    }
    class SomeClass : ISomeRequestClass {
         string Header { ... }
         string SomeClass1 { ... }
         // new: explicit interface implementation
         string ISomeRequestClass.ClassName1 {
              get { return SomeClass1; }
              set { SomeClass1 = value; }
         }
    }
