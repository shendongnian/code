	public class Submission
	 {
		[Key]
		public Int32 Id { get; set; }
		public DateTime Created { get; set; }
		public Int32 ChallengeId { get; set; }
		[ForeignKey("ChallengeId")]
		public virtual Challenge Challenge { get; set; }
		public String YouTubeVideoCode { get; set; }
		public virtual IList<SubmissionVote> Votes { get; set; }
	}
	public class Challenge
	{
		[Key]
		public Int32 Id { get; set; }
		[Required]
		public String ChallengeName { get; set; }
		public virtual IList<Submission> Submissions { get; set; }
		public Int32? OverallWinnerId { get; set; }
		[ForeignKey("OverallWinnerId")]
		public virtual Submission OverallWinner { get; set; }
	}
