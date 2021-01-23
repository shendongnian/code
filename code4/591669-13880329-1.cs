     public class Character
     {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<Stat> Stats { get; set; }
        public Character()
        {
          
        }
        public class Stat
        {
            public int Agility { get; set; }
            public int Strength { get; set; }
            public int Intelligence { get; set; }
            public int Stamina { get; set; }
        }
    }
           
