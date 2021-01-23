    public static class SqlServerKeywords {
         public static readonly HashSet<string> SqlServerReservedKeywords = new HashSet<string> {
        	"ADD",
        	"EXISTS",
        	"PRECISION",
        	"ALL",
        	"EXIT",
        	"PRIMARY",
        	"ALTER",
        	"EXTERNAL",
        	"PRINT",
        	"AND",
        	"FETCH",
        	"PROC",
        	"ANY",
        	"FILE",
        	"PROCEDURE",
        	"AS",
        	"FILLFACTOR",
        	"PUBLIC",
        	"ASC",
        	"FOR"            
         };      
        }
    public class OtherClass {        	  
         private bool Exists (string myWord) {        	  
            var exists = SqlServerReservedKeywords.Contains(myWord);
            return exists;
        }
    }
