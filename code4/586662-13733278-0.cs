    public class ReplicateBlock
    {
        public string   ReplicateId    { get; set; }
        public string   AssayNumber    { get; set; }
        public DateTime InitiationDate { get; set; }
        //etc
    }
    
    public class LogFile
    {
        public List<ReplicateBlock> ReplicateBlocks = new List<ReplicateBlock>();
    }
