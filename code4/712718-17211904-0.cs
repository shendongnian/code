    public class Submission
    {
        public int SubmissionId { get; set; }
        public DateTime Created { get; set; }
        public int ChallengeId { get; set; }
        public string YouTubeVideoCode { get; set; }
        public virtual Challenge Challenge { get; set; }
        public virtual IList<SubmissionVote> Votes { get; set; }
    }
    public class Challenge
    {
        public int ChallengeId { get; set; }
        [Required]
        public string ChallengeName { get; set; }
        public int? OverallWinnerId { get; set; }
        public virtual Submission OverallWinner { get; set; }
        public virtual IList<Submission> Submissions { get; set; }
    }
