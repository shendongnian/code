        subNodes.Add(new OctreeNode(new Vector3(min.X,    min.Y,    min.Z),    new Vector3(center.X, center.Y, center.Z)));
        subNodes.Add(new OctreeNode(new Vector3(min.X,    min.Y,    center.Z), new Vector3(center.X, center.Y, max.Z)));
        subNodes.Add(new OctreeNode(new Vector3(min.X,    center.Y, min.Z),    new Vector3(center.X, max.Y,    center.Z)));
        subNodes.Add(new OctreeNode(new Vector3(min.X,    center.Y, center.Z), new Vector3(center.X, max.Y,    max.Z)));
        subNodes.Add(new OctreeNode(new Vector3(center.X, min.Y,    min.Z),    new Vector3(max.X,    center.Y, center.Z)));
        subNodes.Add(new OctreeNode(new Vector3(center.X, min.Y,    center.Z), new Vector3(max.X,    center.Y, max.Z)));
        subNodes.Add(new OctreeNode(new Vector3(center.X, center.Y, min.Z),    new Vector3(max.X,    max.Y,    center.Z)));
        subNodes.Add(new OctreeNode(new Vector3(center.X, center.Y, center.Z), new Vector3(max.X,    max.Y,    max.Z)));
