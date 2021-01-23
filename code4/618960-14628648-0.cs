      public class Verifier
      {
         public static void Verify(IInterface objectToVerify)
         {
            Contract.Requires<ArgumentException>((objectToVerify is TestClass), "Passed object must be type of TestClass");
    
            // do something ...
         }
      }
