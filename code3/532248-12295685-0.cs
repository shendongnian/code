	class ColorRange
	{
		public Range RedRange { get; set; }
		public Range GreenRange { get; set; }
		public Range BlueRange { get; set; }
	}
	class Range
	{
		public int Minimum { get; set; }
		public int Maximum { get; set; }
		
		public bool IsInRange(int value)
		{
			return value >= this.Minimum && value < this.Maximum;
		}
	}
