    Vector3 DirectionToTravel(bool rotationVecIsInRadians, Vector3 rotationVec)//rotation vec must not be normalized at this point
    {
        Vector3 result;
        if (!rotationVecIsInRadians)
        {
            rotationVec *= MathHelper.Pi / 180f;
        }
        float angle = rotationVec.Length();
        rotationVec /= angle; //normalizes rotation vec
        result = Matrix.CreateFromAxisAngle(rotationVec, angle).Forward;
        return result;
    }
