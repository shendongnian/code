    var intersectingRectangles = new List<List<Rectangle>>();
    var alreadyChecked = new List<int>();
    IEnumerable<int> indices = Enumerable.Range(0, rectangles.Count)
                                         .Except(alreadyChecked);
    foreach (int index in indices)
    {
        var intersections = rectangles
            .Select((r,i) => new{ r, i })
            .Where(x => x.r.IntersectsWith(rectangles[index]));
        alreadyChecked.AddRange(intersections.Select(x => x.i));
        intersectingRectangles.Add(intersections.Select(x => x.r).ToList());
    }
    // now sort descending by the number of intersections(list.Count)
    intersectingRectangles.Sort((rl1,rl2) => (-1) * rl1.Count.CompareTo(rl2.Count));
