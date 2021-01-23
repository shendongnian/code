     public static List<string> ParseFile(String fileToParse)
     {
         int tok;
         Scanner scnr = new Scanner();
         scnr.SetSource(fileToParse, 0);
         do {
                 tok = scnr.yylex();
             } while (tok > (int)Tokens.EOF);
         return butch;
     }
