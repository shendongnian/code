    public static Vector3d Normalize(this Vector3d v, out double norm)
    {
        norm = v.Norm();
        var invNorm = 1.0 / norm;
    
        // Using a constructor with x, y, z parameters would be preferable,
        // if it exists.
        v.X *= invNorm;
        v.Y *= invNorm;
        v.Z *= invNorm;
    
        return v;
    }
