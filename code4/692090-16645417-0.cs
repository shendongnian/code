       public class Terrain
        {
                public int IChance { get; private set; }
        public int Chancepoint { get; private set; }
        public int Octaves { get; private set; }
        public int LengthMin { get; private set; }
        public int LengthMax { get; private set; }
        public float ScaleMin { get; private set; }
        public float ScaleMax { get; private set; }
        public float PersistenceMin { get; private set; }
        public float PersistenceMax { get; private set; }
        public pType Ptype { get; private set; }
        public bTag[] Tags { get; private set; }
    
            public static Terrain Desert()
            {
                return new Terrain
                    {
                        IChance = 15,
                        Chancepoint = 0,
                        Octaves = 4,
                        LengthMin = 60,
                        LengthMax = 90,
                        ScaleMin = 250,
                        ScaleMax = 350,
                        PersistenceMin = 0.5f,
                        PersistenceMax = 0.9f,
                        Ptype = pType.Lowland,
                        Tags = new bTag[] {bTag.Desert}
                    };
            }
    }
