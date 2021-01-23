    public class MapRec
    {
        private const int MAX_MAP_NPCS = 25;
        private int fixedLength1 = 10;
        private string _name;
    
        public string Name
        {
            get
            {
                return _name;
            }
            set
    	    {
                if (value.Length != fixedLength1)
                {
                    if (value.Length < fixedLength1)
                    {
                        _name = value.PadRight(fixedLength1);
                    }
                    else
                    {
                        _name = value.Substring(0,fixedLength1);
                        // or alternatively throw an exception if 
                        // a 11+ length string comes in
                    }
                }
                else
                {
                    _name = value;
                }
    	    }
        }
    
        // Constructor
        public MapRec()
        {
            Npc = new int[MAX_MAP_NPCS];
            NpcSpawn = new SpawnRec[MAX_MAP_NPCS];
        }
    
        public long Revision { get; set; }
        public byte Moral { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public string Music { get; set; }
        public int BootMap { get; set; }
        public byte BootX { get; set; }
        public byte BootY { get; set; }
        public TileRec[] Tile { get; set; }
        public int[] Npc { get; set; }
        public SpawnRec[] NpcSpawn { get; set; }
        public int TileSet { get; set; }
        public byte Region { get; set; }
    }
