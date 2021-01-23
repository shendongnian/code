	public struct AABB
	{
		public float X, Y, Width, Height;
		public static AABB Intersect(AABB a, AABB b)
		{
			AABB result;
			result.X = Math.Max(a.X, b.X);
			result.Y = Math.Max(a.Y, b.Y);
			result.Width = Math.Min(a.X + a.Width, b.X + b.Width) - result.X;
			result.Height = Math.Min(a.Y + a.Height, b.Y + b.Height) - result.Y;
			if(result.Width < 0 || result.Height < 0)
				return default(AABB);
			else
				return result;
		}
	}
