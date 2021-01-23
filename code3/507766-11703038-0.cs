           namespace ClassLibrary1
           {
               public static class Class1
               {
                   public static void Macro1(EnvDTE80.DTE2 DTE)
                   {
                       // make sure an active text document is open before calling this method
                       DTE.ActiveDocument.Selection.Insert("Hello World!!!");
                   }
               }
           }
