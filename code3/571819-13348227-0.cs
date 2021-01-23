    public GameObject CreateObject()
    {
        string key = GetType().FullName;
        List<vertex> points = null;
        if (PointsPerClass.ContainsKey(key))
          points = PointsPerClass[key];
        else {
          points = new List<vertex>()
          PointsPerClass.Add(key, points);
          FillStaticVertices(points);
        }
    
        // CreateObjectFromPoints is an abstract method implemented by descendants
        GameObject gameObj = CreateObjectFromPoints(points);
        // apply textures, rotations, etc
        return gameObj;
    }
