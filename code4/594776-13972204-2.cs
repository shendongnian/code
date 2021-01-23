	public class PointCount
	{
		public CustomPoint Point { get; set; }
		public int Count { get; set; }
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
