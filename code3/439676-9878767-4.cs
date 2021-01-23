    /*public*/ class JonSkeetClass  /*the visibility of this class depends on where you'll be using it*/
        {
             public struct ReportDetails /*this needs to be public also (or internal)*/
             {
                 ....
             }
             public static  IList<ReportDetails> GetMyArray
             {
                 get
                 {
                    return MyArray;
                 }
             }
              
        }
