    static System.Random prng = new System.Random();
    public static Vector2 genControlPoint(Vector2 l, Vector2 r)
    {
        // get a random angle between +/-(15..90) degrees off line
        float angle = (float)((((prng.NextDouble() * 5) + 1) / 12) * Math.PI * (prng.Next(0, 2) * 2 - 1));
        // create rotation matrix
        Matrix rot = Matrix.CreateRotationZ(angle);
        // get point offset half-way between two points
        Vector2 ofs = Vector2.op_Multiply(Vector2.op_Subtract(l, r), 0.5);
        // apply rotation
        ofs = Vector2.Transform(ofs, rot);
        // return point as control
        return Vector2.op_Add(l, ofs);
    }
    ....
    Vector2 p0 = FlyStartPoint();
    Vector2 p1 = FlyEndPoint();
    // generate randomized control points for flight path
    Vector2 c0 = genControlPoint(p0, p1);
    Vector2 c1 = genControlPoint(p1, p0);
