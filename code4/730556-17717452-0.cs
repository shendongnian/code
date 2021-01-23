    public class ChainTypes
    {
        public ChainType none;
        public ChainType unknown;
        public ChainType horizontal;
        public ChainType vertical;
        public ChainType centerCross;
        public ChainType leftTopCornerCross;
        public ChainType rightTopCornerCross;
        public ChainType leftBottomCornerCross;
        public ChainType rightBottomCornerCross;
    }
    ChainTypes types = new ChainTypes();
    ChainType chaintype = getChainType();   
    if (chainType == types.horizontal) {
    }
    
    
