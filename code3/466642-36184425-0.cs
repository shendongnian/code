     public class Foo {
         public string Id {get; set; }
         public string BarId {get; set; }
         // lazy loaded relationship to bar
         public virtual Bar Bar { get; set;}
     }
     var foo = new Foo {
         Id = "foo id"
         BarId = "some existing bar id"
     };
     dbContext.Set<Foo>().Add(foo);
     dbContext.SaveChanges();
     // some other code, using the same context
     var foo = dbContext.Set<Foo>().Find("foo id");
     var barProp = foo.Bar.SomeBarProp; // fails with null reference even though we have BarId set.
