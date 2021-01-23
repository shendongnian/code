    public static class MemoryCardFactory
        {
            public static MemoryCard Sd2GB { get { return MemoryCard(MemoryCardType.xd, MemoryCardSize.TwoGB); } }
            public static MemoryCard Sd4GB { get { return MemoryCard(MemoryCardType.xd, MemoryCardSize.FourGB); } }
            public static MemoryCard Sd8B { get { return MemoryCard(MemoryCardType.xd, MemoryCardSize.EightGB); } }
    
            public static MemoryCard Xd2GB { get { return MemoryCard(MemoryCardType.xd, MemoryCardSize.TwoGB); } }
            public static MemoryCard Xd4GB { get { return MemoryCard(MemoryCardType.xd, MemoryCardSize.FourGB); } }
            public static MemoryCard Xd8GB { get { return MemoryCard(MemoryCardType.xd, MemoryCardSize.EightGB); } }
    
            public static MemoryCard MicroSd2GB { get { return MemoryCard(MemoryCardType.MicroSd, MemoryCardSize.TwoGB); } }
            public static MemoryCard MicroSd4GB { get { return MemoryCard(MemoryCardType.MicroSd, MemoryCardSize.FourGB); } }
            public static MemoryCard MicroSd8GB { get { return MemoryCard(MemoryCardType.MicroSd, MemoryCardSize.EightGB); } }
        }
