	public static class RandomExtensions
	{
		public static double RandNumb(
			this Random @this,
			double minimum, double maximum, double step)
		{
			var lowest = System.Math.Ceiling(minimum / step) * step;
			var highest = System.Math.Floor(maximum / step) * step;
			var numbers = (int)(1 + (highest - lowest) / step);
			var index = @this.Next(0, (int)numbers);
			return lowest + index * step;
		}
	}
