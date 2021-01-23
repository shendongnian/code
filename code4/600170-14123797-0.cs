    static class GlobalVars
    {
        public static TTamagotchiPet Pet1 { get; set; }
        static GlobalVars() 
        {
            Pet1 = new TTamagotchiPet();
        }
    }
