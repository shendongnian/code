    public class MyClass
    {
       ...
    
       //Don't map this field in FluentNH; this is for in-code use
       public DateTime MyDate 
       {
          get{return MyDateUTC.ToLocalTime();} 
          set{MyDateUTC = value.ToUniversalTime();}
       }
    
       //map this one instead; can be private as well
       public DateTime MyDateUTC {get;set;} 
    }
    ...
    public class MyClassMap:ClassMap<MyClass>
    {
       public MyClassMap()
       {
          Map(x=>x.MyDateUTC).Column("MyDate");
          //if you made the UTC property private, map it this way instead:
          Map(Reveal.Member<DateTime>("MyDateUTC")).Column("MyDate");
       }
    }
