    static class GlobalVars     // Static class used to store pet values as 'global' variables.
    {
        static GlobalVars
        {
          Pet1 = new TTamagotchi();
          Pet2 = new TTamagotchi();
          Pet3 = new TTamagotchi();
          Pet4 = new TTamagotchi();
        }
    
        public static TTamagotchiPet Pet1 { get; set; }
        public static TTamagotchiPet Pet2 { get; set; }
        public static TTamagotchiPet Pet3 { get; set; }
        public static TTamagotchiPet Pet4 { get; set; }
    }
