	internal class Container
	{
		public int Id { get; set; }
		public DateTime Start { get; set; }
		public DateTime Stop { get; set; }
		public override string ToString()
		{
			return "ID " + Id + ": " + Start + " -> " + Stop;
		}
	}
