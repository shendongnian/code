    public class FunkyDerivedA : FunkyBase
    { 
       public SomeProperty { get; set; } 
    }
    ///// SNIP /////
    FunkyBase funky = FunkyFactory.Create("A");  
    funky.SomeProperty = 7;
