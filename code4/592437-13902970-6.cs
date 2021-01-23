    Matrix worldMatrix;
    Matrix viewMatrix;
    Matrix projectionMatrix;
    BasicEffect basicEffect;
    VertexPositionColor[] pointList;
    short[] lineListIndices;
    protected override void Initialize()
    {
        int n = 300;
        //GeneratePoints generates a random graph, implementation irrelevant
        pointList = new VertexPositionColor[n];
        for (int i = 0; i < n; i++)
            pointList[i] = new VertexPositionColor() { Position = new Vector3(i, (float)(Math.Sin((i / 15.0)) * height / 2.0 + height / 2.0 + minY), 0), Color = Color.Blue };
        //links the points into a list
        lineListIndices = new short[(n * 2) - 2];
        for (int i = 0; i < n - 1; i++)
        {
            lineListIndices[i * 2] = (short)(i);
            lineListIndices[(i * 2) + 1] = (short)(i + 1);
        }
        worldMatrix = Matrix.Identity;
        viewMatrix = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 1.0f), Vector3.Zero, Vector3.Up);
        projectionMatrix = Matrix.CreateOrthographicOffCenter(0, (float)GraphicsDevice.Viewport.Width, (float)GraphicsDevice.Viewport.Height, 0, 1.0f, 1000.0f);
        basicEffect = new BasicEffect(graphics.GraphicsDevice);
        basicEffect.World = worldMatrix;
        basicEffect.View = viewMatrix;
        basicEffect.Projection = projectionMatrix;
        basicEffect.VertexColorEnabled = true; //important for color
        base.Initialize();
    }
