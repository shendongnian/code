    public class Parent 
    { 
      public int Age { get; set; }
    }
    
    public class Child : Parent 
    {
      // This will get the 'base' class property
      public int AgePlusFive { get { return base.Age + 5; } }
    }
