	public class ReduceResult: IEquatable<ReduceResult>
	{
		public string Text { get; set; }
		public string UserName { get; set; }
		public string ProfileImageUrl { get; set; }
		
		public bool Equals(ReduceResult other)
		{
		}
		public override int GetHashCode()
		{
		}	
	}
