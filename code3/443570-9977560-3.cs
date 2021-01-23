    struct PESHeader 
    { 
        [Bitfield(0, 2)] 
        public uint reserved; 
        [Bitfield(1, 2)] 
        public uint scrambling_control; 
        [Bitfield(2, 1)] 
        public uint priority; 
        [Bitfield(3, 1)] 
        public uint data_alignment_indicator; 
        [Bitfield(4, 1)] 
        public uint copyright; 
        [Bitfield(5, 1)] 
        public uint original_or_copy; 
    }
