    public class character
    {
        public string Name, Owner;
        public int AC, Speed, maxHP, currHP, AP, SV, Surges;
        public Stat Str { get; set; }
        public Stat Con { get; set; }
        public Stat Dex { get; set; }
        public Stat Int { get; set; }
        public Stat Wis { get; set; }
        public Stat Cha { get; set; }
        public class Stat
        {
            public Stat(int stat)
            {
               Value = stat;
            }
            public int Value { get; set; }
            public int Mod { get { /*Calcuate Mod from Value.*/; } }
        }
