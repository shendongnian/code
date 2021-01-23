    public class ClaimMap
    {
        public ClaimMapField Name{get;set;}
        ...
    }
    public class ClaimMapField
    {
        public int StartingLine{get;set;}
        // I would have the parser subtract one when creating this, to make it 0-based.
        public int StartingCharacter{get;set;}
        public int MaxLength{get;set;}
    }
