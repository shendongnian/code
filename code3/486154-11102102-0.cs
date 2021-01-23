    class Dog{
      public int Id {get; set;} //CF will automatically recognise this as a primary key
      public virtual <List>Leg Legs{get; set;} //automagical navigation property
    }
    class Leg{
      public int Id {get; set;} //idem
      public virtual Dog PartOf {get; set;} //automagical navigation property
    }
  
  
