    public static class Core 
    { 
 
        Dig dig; 
 
        public static Core() 
        { 
            dig = new Dig(); 
        } 
 
 
        public static void startTest() 
        { 
            dig.resolver.DnsServer = "10.10.10.10";// <------ ERROR 
        }
   }
}
