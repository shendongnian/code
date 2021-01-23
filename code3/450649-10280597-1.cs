    public class ChallengesResult : Result<ChallengeResource>
    {
        public ChallengesResult()
            : base()
        {
        }
        
        [XmlElement("Challenge")]
        public override List<ChallengeResource> Items { get; set; }
    }
