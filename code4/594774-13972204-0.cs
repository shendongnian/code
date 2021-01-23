		static void Main(string[] args)
		{
			List<CustomPoint> list1 = CreateCustomPointList();
			var result = GetDoubles(list1);
		}
		private static IEnumerable<CustomPoint> GetDoubles(List<CustomPoint> pointList)
		{
			var allPoints = new Dictionary<int, PointCount>();
			foreach (var point in pointList)
			{
				int hash = point.GetHashCode();
								
				if (allPoints.ContainsKey(hash))
				{
					allPoints[hash].Count++;
				}
				else
				{
					allPoints.Add(hash, new PointCount { Point = point, Count = 1 });
				}
			}
			return allPoints.Where(p => p.Value.Count == 2).Select(p => p.Value.Point);
		}
		private static List<CustomPoint> CreateCustomPointList()
		{
			var result = new List<CustomPoint>();
			result.Add(new CustomPoint(0, 1));
			result.Add(new CustomPoint(0, 2));
			result.Add(new CustomPoint(0, 3));
			result.Add(new CustomPoint(1, 1));
			result.Add(new CustomPoint(1, 2));
			result.Add(new CustomPoint(1, 3));
			result.Add(new CustomPoint(2, 1));
			result.Add(new CustomPoint(2, 2));
			result.Add(new CustomPoint(2, 3));
			result.Add(new CustomPoint(3, 1));
			result.Add(new CustomPoint(3, 2));
			result.Add(new CustomPoint(3, 3));
			return result;
		}
	}
	
	public class PointCount
	{
		public CustomPoint Point { get; set; }
		public int Count { get; set; }
	}
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
			int hash = 0;
			hash ^= this.X.GetHashCode();
			hash ^= this.Y.GetHashCode();
			return hash;
		}
	}
