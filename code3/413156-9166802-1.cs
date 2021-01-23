    public static float DirectionalAngle(Vector3 from, Vector3 to, Vector3 up)
    {
        // project the vectors on the plane with up as a normal
        Vector3 f = Vector3.Exclude(up, from);
        Vector3 t = Vector3.Exclude(up, to);
        Quaternion fromTo = Quaternion.FromToRotation(f,t); // make a rotation quaternion
        Quaternion toZ = Quaternion.FromToRotation(up, Vector3.up); // NEW: correct up axis
        // rotate the quaternion in the correct space to measure the euler angle
        fromTo = toZ * fromTo; // NEW
        // rotate the y-rotation in euler angles
        return fromTo.eulerAngles.y;
    }
