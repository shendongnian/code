    public void CompRoot()
    {
         var bar = new ReadonlyDictionary(
             ... initialize with desired values ...
              // also this object is not in .NET but there
              // are many available on the net
         );
         var obj = new UsesBarDependency(bar);
    }
    public class UsesBarDependency
    {
         private readonly ReadonlyDictionary bar;
       
         public UsesBarDependency(ReadonlyDictionary bar)
         {
              if (bar == null)
                  throw new ArgumentNullException("bar");
              this.bar = bar;
         }
         public void Func()
         {
             // use to access the dependency
             this.bar 
             // over
             Foo.Bar
         }
     }
