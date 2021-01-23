	public class PointCount
	{
		public CustomPoint Point { get; set; }
		public int Count { get; set; }
	}
	private static IEnumerable<CustomPoint> GetPointsByCount(Dictionary<int, PointCount> pointcount, int count)
	{
		return pointcount
						.Where(p => p.Value.Count == count)
						.Select(p => p.Value.Point);
	}
	private static Dictionary<int, PointCount> GetPointCount(List<CustomPoint> pointList)
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
		return allPoints;
	}
