    private float worldRotation = 0;
    public void RevolveAroundFocusPoint(float relativeDegrees)
    {
        worldRotation += MathHelper.ToRadians(relativeDegrees);
    }
    public Vector3 Modified
    {
        get
        {
            Vector3 f = Vector3.Transform(Focus, Matrix.Invert(Matrix.CreateRotationY(worldRotation)));
            return new Vector3(f.X, Position.Y, f.Z);
        }
    }
    public float Multiplier(float value, Vector3 v3)
    {
        return value / /*Zoom / */ ((v3.X < 0 ? -v3.X : v3.X) + (v3.Z < 0 ? -v3.Z : v3.Z));
    }
    public void MoveRight(float value)
    {
        Vector3 f = Modified;
        float multiplier = Multiplier(value, f);
        Position += new Vector3(f.Z * multiplier, 0, f.X * multiplier);
    }
    public void MoveLeft(float value)
    {
        Vector3 f = Modified;
        float multiplier = Multiplier(value, f);
        Position += new Vector3(-f.Z * multiplier, 0, -f.X * multiplier);
    }
    public void MoveBackward(float value)
    {
        Vector3 f = Modified;
        float multiplier = Multiplier(value, f);
        Position += new Vector3(-f.X * multiplier, 0, f.Z * multiplier);
    }
    public void MoveForward(float value)
    {
        Vector3 f = Modified;
        float multiplier = Multiplier(value, f);
        Position += new Vector3(f.X * multiplier, 0, -f.Z * multiplier);
    }
    public Matrix World;
    public Matrix View;
    public Matrix Proj;
    public Vector3 Position { get; private set; }
    public Vector3 Focus;
    public void Update()
    {
        World = Matrix.CreateTranslation(-Position - Focus) *
            Matrix.Invert(Matrix.CreateRotationY(worldRotation)) *
            Matrix.CreateScale(Zoom) *
            Matrix.CreateTranslation(Position + Focus);
        View = Matrix.CreateLookAt(Position, Position + Focus, Vector3.Up);
    }
