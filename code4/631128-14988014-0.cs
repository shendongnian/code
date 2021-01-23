    public Matrix ViewMatrix
    {
        get
        {
            return Matrix.CreateLookAt(Position, Forward+Position, Vector3.Up);//changed the 3rd param from Up toVector3.Up
        }
    }
