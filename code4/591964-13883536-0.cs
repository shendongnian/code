	public class ProjectView {
		public int ProjectID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public virtual ICollection<TagView> Tags { get; set; }
	}
	public class ProjectTagView {
	   public int TagID { get; set; }
	   public string TagValue { get; set; }
	   public int TagCount { get; set; }
	}
