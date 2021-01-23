    bool IsIntersecting(IAABox box, ITriangle triangle)
    {
        var boxNormals = new IVector[]{new Vector(1,0,0), new Vector(0,1,0), new Vector(0,0,1)};
        double minOffset, maxOffset;
        for (int i = 0; i < 3; i++)
        {
            IVector n = boxNormals[i];
            minOffset = double.PositiveInfinity;
            maxOffset = double.NegativeInfinity;
            foreach (IVector p in triangle.Vertices)
            {
                var offset = n.Dot(p);
                if (offset < minOffset) minOffset = offset;
                if (offset > maxOffset) maxOffset = offset;
            }
            if (maxOffset < box.Start.Coords[i] || minOffset > box.End.Coords[i])
                return false; // No intersection possible.
        }
        minOffset = double.PositiveInfinity;
        maxOffset = double.NegativeInfinity;
        foreach (IVector p in box.Vertices)
        {
            var offset = triangle.Normal.Dot(p);
            if (offset < minOffset) minOffset = offset;
            if (offset > maxOffset) maxOffset = offset;
        }
        double triangleOffset = triangle.Normal.Dot(triangle.A);
        if (maxOffset < triangleOffset || minOffset > triangleOffset)
            return false; // No intersection possible.
        else
            return true; // No separating plane found. There must be an intersection.
    }
    interface IVector
    {
        double X { get; }
        double Y { get; }
        double Z { get; }
        double[] Coords { get; }
        double Dot(IVector other);
    }
    interface IShape
    {
        IEnumerable<IVector> Vertices { get; }
    }
    interface IAABox : IShape
    {
        IVector Start { get; }
        IVector End { get; }
    }
    interface ITriangle : IShape {
        IVector Normal { get; }
        IVector A { get; }
        IVector B { get; }
        IVector C { get; }
    }
