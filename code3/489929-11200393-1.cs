    public enum VoteType { Unanimous = 1, SimpleMajority = 2, ... }
  
    public static readonly Dictionary<VoteType, string> VoteDescriptions = new Dictionary<VoteType, string>
    {
        { VoteType.Unanimous, "Unanimous description" },
        { VoteType.SimpleMajority, "Simple majority" },
        ...
    };
