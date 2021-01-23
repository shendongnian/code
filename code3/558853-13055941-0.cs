	public class StudentCourse
	{
		public StudentCourse()
		{
			this.Comments = new List<Comment>();
		}
		public int StudentCourseId { get; set; }
		public int StudentId { get; set; }
		public int CourseId { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual Course Course { get; set; }
		public virtual Student Student { get; set; }
	}
