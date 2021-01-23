    string code = string.Format  // Note: Use "{{" to denote a single "{" 
    ( 
       "public static class Func{{ public static Acos(double d) { return Math.ACos(d); }
                                   public static int func(){{ return {0};}}}}", expression 
    );
