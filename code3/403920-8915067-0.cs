    public class FunkyDerivedA { public SomeProperty { get; set; } }
    // notice it doesn't have the same property
    public class FunkyDerivedB { } 
    ///// SNIP /////
    // Danger, Will Robinson!
    FunkyBase funky = FunkyFactory.Create("B");  
    funky.SomeProperty = 7;
