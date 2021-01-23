        public abstract class Terrain
        {
            public int iChance;
            public int chance;
            public int chancepoint;
            public int octaves;
            public int lengthMin;
            public int lengthMax;
            public float scaleMin;
            public float scaleMax;
            public float persistenceMin;
            public float persistenceMax;
            public pType ptype;
            public Tag[] strongTags;
        }
    
        public class Desert : Terrain
        {
    
        }
    
        public enum pType
        {
            Desert = 1,
            LowLand = 2
        }
    
        public enum Tag
        {
            desert = 1,
            lush = 2
        }
