    [Serializable]
    public class challenge
    {
        public class Team
        {
            public string TeamName { get; set; } 
        }
        public class Member:Team
        {
            public string Name { get; set; }
        }
    
        [Serializable]
        public class ChallengeList
        {
            public List<Member> Member()
            {
                return null;
            }
        }
    }
