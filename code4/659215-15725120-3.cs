    public class A
    {
      public virtual int Id {get;set;}
      public virtual string P1 {get;set;}
      public virtual string P2 {get;set;}
      public virtual string P3 {get;set;}
      public virtual B child { get; set; }
    }
    public class B
    {
      public virtual int Id {get;set;}
      public virtual string P4 {get;set;}
      public virtual string P5 {get;set;}
      public virtual string P6 {get;set;}
      public virtual A parent;
    }
