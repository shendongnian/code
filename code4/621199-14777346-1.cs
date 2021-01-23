     if (shapeChecker.IsCircle(edgePoints, out center, out radius))
     {
         circs.Add(b);
     }
     else if (corners.Count == 3)
        tris.Add(b);
     else if (corners.Count == 4)
        boxes.Add(b);
