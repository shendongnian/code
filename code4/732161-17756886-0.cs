    public Ray Reflect(Ray ray, Point3D crossPoint, Triangle3D intersect)
    {
        Point3D V = -ray.Direction.Normalize();
        return new Ray(crossPoint, 
                       V - 2 * intersect.Normal * (V * intersect.Normal), 
                       Color.white);
    }
