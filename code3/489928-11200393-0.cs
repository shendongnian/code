    public enum VoteType { Unanimous, SimpleMajority, ... }
  
    public static readonly Dictionary<VoteType, string> VoteDescriptions = new Dictionary<VoteType, string>
    {
        { VoteType.Unanimous, "Unanimous description" },
        { VoteType.SimpleMajority, "Simple majority" },
        ...
    };
