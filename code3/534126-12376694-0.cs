       public class FooBarMap: ComponentMap<FooBar>
           {
               public FooBarMap()
               {
                   Map(x => x.FoobarProp1);
                   Map(x => x.FoobarProp2);
               }
           }
