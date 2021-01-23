     public class MyGenericClassBase { }
     public class MyGenericClass<T> : MyGenericClassBase { }
     public class MyClass<TGen> 
          where TGen: MyGenericClassBase
     {
         // Stuff
     }
