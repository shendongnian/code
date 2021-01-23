    public static float DirectionalAngle(Vector3 from, Vector3 to, Vector3 up)
    {
        // project the vectors on the plane with up as a normal
        Vector3 f = Vector3.Exclude(up, from);
        Vector3 t = Vector3.Exclude(up, to);
	
        // rotate the vectors into y-up coordinates
        Quaternion toZ = Quaternion.FromToRotation(up, Vector3.up);
        f = toZ * f;
        t = toZ * t;
        // calculate the quaternion in between f and t.
        Quaternion fromTo = Quaternion.FromToRotation(f,t);
        // return the eulers.
        return fromTo.eulerAngles.y;
    }
