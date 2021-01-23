     public class Foo {
       const string SOMEKEY = "_somekey";
   
       public static string SingleRequestVariable
       {
          get
          {
              return (string)HttpContext.Current.Items[SOMEKEY];   
          }
          set
          {
              HttpContext.Current.Items.Add( SOMEKEY, value );
          }
       }
     }
