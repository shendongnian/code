	public class Comment
	{
		public int CommentId { get; set; }
		public int StudentCourseId { get; set; }
		public virtual StudentCourse StudentCourse { get; set; }
		...
	}
