	public static IEnumerable<Point> ComputeConvexHull(List<Point> points, bool sortInPlace = false)
	{
		if (!sortInPlace)
			points = new List<Point>(points);
		points.Sort((a, b) => { return a.X.CompareTo(b.X); });
		// Importantly, DList provides O(1) insertion at beginning and end
		DList<Point> hull = new DList<Point>();
		int L = 0, U = 0;
		for (int i = points.Count - 1; i >= 0 ; i--)
		{
			// right turn (clockwise) => negative cross product (for Y-up coords)
			Point p = points[i], p1;
			// build lower hull
			while (L >= 2 && (p1 = hull.Last).Sub(hull[hull.Count-2]).Cross(p.Sub(p1)) >= 0) {
				hull.RemoveAt(hull.Count-1);
				L--;
			}
			hull.PushLast(p);
			L++;
			// build upper hull
			while (U >= 2 && (p1 = hull.First).Sub(hull[1]).Cross(p.Sub(p1)) >= 0)
			{
				hull.RemoveAt(0);
				U--;
			}
			if (U != 0) // when U=1, share the point added above
				hull.PushFirst(p);
			U++;
			Debug.Assert(U + L == hull.Count + 1);
		}
		hull.RemoveAt(hull.Count - 1);
		return hull;
	}
