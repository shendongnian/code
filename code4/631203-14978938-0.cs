    Vector3 Position;
    float Rotation;
    
    Matrix World
    {
        get
        {
            return Matrix.CreateRotationZ(Rotation) * Matrix.CreateTranslation(Position);
        }
    }
    
    public void RotateInstantly(Vector3 position)
    {
        Rotation = Math.Atan2(Position.Y - position.Y, Position.x - position.x);
    }
    
    public void RotateIncremently(Vector3 position, float maxStep)
    {
        float targetRotation = Math.Atan2(Position.Y - position.Y, Position.x - position.x);
        float diff = targetRotation - Rotation;
    
        if (Math.Abs(diff) > maxStep)
        {
            if (targetRotation > Rotation)
                Rotation += maxStep;
            else
                Rotation -= maxStep;
        }
        else
            Rotation = targetRotation;
    }
