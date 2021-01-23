    [Serializable]
    public class challenge
    {
        [Serializable]
        public class Team
        {
            public string TeamName { get; set; } 
        }
        [Serializable]
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
