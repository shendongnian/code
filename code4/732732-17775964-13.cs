    // Converts the latitude/longitude coordinates to 3D coordinates
    List<Vector3> pointsIn3D = (from point in points
                                select GeographicCoordinatesToPoint(point.Latitude, point.Longitude))
                               .ToList();
    // Gets the centroid (to have the normal of the vector space)
    Vector3 centroid = GetCentroid(pointsIn3D );
    // As we are on a sphere, the normal at a given point is the colinear to the vector going from the center of the sphere to the point.
    Vector3 normal = (1f / centroid.Length) * centroid;  // We want a unitary normal.
    // Finally the area is computed using:
    float area = GetArea(pointsIn3D, normal);
