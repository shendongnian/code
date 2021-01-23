    private void SetCorners<T>(T position, int width, int height)
        where T : MyVectorWrapper
    {
        float halfWidth = width / 2 + position.X;
        float halfHeight = height / 2 + position.Y;
        UpperLeft = new Vector2(-halfWidth, -halfHeight);
        UpperRight = new Vector2(halfWidth, -halfHeight);
        LowerLeft = new Vector2(-halfWidth, halfHeight);
        LowerRight = new Vector2(halfWidth, halfHeight);
    }
    class MyVectorWrapper
    {
        public float X { get; set; }
        public float Y { get; set; }
        public MyVectorWrapper(dynamic vector2)
        {
            X = vector2.X;
            Y = vector2.Y;
        }
    }
