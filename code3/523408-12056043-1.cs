    class User
    {
        public int UserId {get; set;}
    }
    class Question
    {
        public int QuestionId { get; set; }
    }
    class Vote
    {
        public int VoteId {get; set;}
        public DateTime TimeStamp {get; set;}
        public Question Question {get; set;}
        public User User { get; set; }
    }
    class VoteResult
    {
        public int QuestionId { get; set; }
        public float Percentage { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var question1 = new Question();
            question1.QuestionId = 1;
    
            var question2 = new Question();
            question2.QuestionId = 2;
    
            var user1 = new User();
            user1.UserId = 1;
    
            var user2 = new User();
            user2.UserId = 2;
    
            var user3 = new User();
            user3.UserId = 3;
    
            List<Vote> votes = new List<Vote>()
            {
                new Vote(){ Question = question2, TimeStamp = DateTime.Today.AddDays(-1), User = user1, VoteId = 1},
                new Vote(){ Question = question1, TimeStamp = DateTime.Today, User = user1, VoteId = 2},
                new Vote(){ Question = question2, TimeStamp = DateTime.Today.AddDays(-1), User = user2, VoteId = 3},
                new Vote(){ Question = question1, TimeStamp = DateTime.Today.AddDays(-1), User = user3, VoteId = 4},
            };
    
            // Group Votes by User and then Select only the most recent Vote of
            // each User
            var results = from vote in votes
                            where vote.TimeStamp >= DateTime.Today.AddDays(-7) && vote.TimeStamp < DateTime.Today.AddDays(1)
                            group vote by vote.User into g
                            select g.OrderByDescending(v => v.TimeStamp).First();
    
            var total = results.Count();
    
            foreach (var result in results.GroupBy(v => v.Question.QuestionId))
            {
                var voteResult = new VoteResult()
                {
                    QuestionId = result.Key,
                    Percentage = ((float)result.Count() / total) * 100.0f
                };
    
                Console.WriteLine(voteResult.QuestionId);
    
                Console.WriteLine(voteResult.Percentage);
            }
    
        }
    }
