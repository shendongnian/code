    Class1{
      public int idClass { get; set; }
      public Class2 classObject { get; set; }
    
      public int idClass2 { 
        get { return classObject.idClass2; }
        set { classObject.idClass2 = value; }
      }
    }
