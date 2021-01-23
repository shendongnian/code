    public Vector3 GetRight()
    {
        Matrix rotation = Matrix.CreateFromYawPitchRoll(orientation.Y, orientation.X, orientation.Z);
        return new Vector3(rot.M11, rot.M21, rot.M31);
    }
    public Vector3 GetUp()
    {
        Matrix rotation = Matrix.CreateFromYawPitchRoll(orientation.Y, orientation.X, orientation.Z);
        return new Vector3(rot.M12, rot.M22, rot.M32);
    }
