    public Vector3 GetRight()
    {
        Matrix rotation = Matrix.CreateFromYawPitchRoll(orientation.Y, orientation.X, orientation.Z);
        return new Vector3(rotation.M11, rotation.M21, rotation.M31);
    }
    public Vector3 GetUp()
    {
        Matrix rotation = Matrix.CreateFromYawPitchRoll(orientation.Y, orientation.X, orientation.Z);
        return new Vector3(rotation.M12, rotation.M22, rotation.M32);
    }
