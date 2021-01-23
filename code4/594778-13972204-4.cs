	public class CustomPoint
	{
		public double X { get; set; }
		public double Y { get; set; }
		public CustomPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}
		public override bool Equals(object obj)
		{
			var other = obj as CustomPoint;
			if (other == null)
			{
				return base.Equals(obj);
			}
			return ((this.X == other.X) && (this.Y == other.Y));
		}
		public override int GetHashCode()
		{
			int hash = 23;
			hash = hash * 31 + this.X.GetHashCode();
			hash = hash * 31 + this.Y.GetHashCode();
			return hash;
		}
	}
