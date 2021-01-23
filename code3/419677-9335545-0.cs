    struct Block
    {
        // I'd definitely get rid of the HasMetaData
        private readonly byte id;
        private readonly BlockMetaData metaData;
        public Block(byte id, BlockMetaData metaData)
        {
            this.id = id;
            this.metaData = metaData;
        }
        public byte Id { get { return id; } }
        public BlockMetaData { get { return blockMetaData; } }
        public Block WithId(byte newId)
        {
            return new Block(newId, metaData);
        }
        public Block WithMetaData(BlockMetaData newMetaData)
        {
            return new Block(id, newMetaData);
        }
    }
