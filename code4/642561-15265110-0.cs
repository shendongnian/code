	public class Result
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long ResultId { get; set; }
		public long? TeamId { get; set; }
	
		public Team Team { get; set; }
	}
