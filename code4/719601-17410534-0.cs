     public class MyClass { 
         private static readonly List<MyObject> listObject = 
                  new List<MyObject> { new MyObject() };
         private static readonly MyObject obj = 
                  new MyObject { parent = listObject[0] };
     }
