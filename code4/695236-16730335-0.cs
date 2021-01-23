    class Person {
      [Browsable(false)]
      public int ID {get; set;}
      public string Name { get; set; }
      public string Surname { get; set; }
      [DisplayName("Birth Date")]
      public DateTime BDate { get; set; }
    }
