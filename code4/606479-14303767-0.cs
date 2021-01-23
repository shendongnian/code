    public static class Globals
    {
        public static string Name { get; set; }
        public static int aNumber {get; set; }
        public static List<string> onlineMembers = new List<string>();
    
         static Globals()
         {
            Name = "starting name";
            aNumber = 5;
         }
    }
