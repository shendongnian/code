	public class Video
	{
		public int Id { get; set; }
		// Adding this doesn't change the db/schema, but it is enforced in code if
		// you try to add a Video without a MediaContent.
		[Required]
		public MediaContent MediaContent { get; set; }
	}
	public class MediaContent
	{
		[ForeignKey("Video")]
		public int Id { get; set; }
		public Video Video { get; set;}
	}
