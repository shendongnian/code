    var intersectingRectangles = new List<List<Rectangle>>();
    var alreadyChecked = new HashSet<Rectangle>();
    var toCheck = rectangles.Except(alreadyChecked);
    while (alreadyChecked.Count != rectangles.Count)
    {
        var intersections = toCheck.Where(r => r.IntersectsWith(toCheck.ElementAt(0)))
                                   .ToList();
        intersectingRectangles.Add(intersections);
        foreach (var r in intersections)
            alreadyChecked.Add(r);
    }
    intersectingRectangles.Sort((rl1, rl2) => (-1) * rl1.Count.CompareTo(rl2.Count));
