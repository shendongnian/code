    GraphicsDevice.Clear(Color.CornflowerBlue);
    GraphicsDevice.BlendState = BlendState.NonPremultiplied;
    effect.TextureEnabled = true;
    effect.VertexColorEnabled = true;
    effect.World = Matrix.CreateTranslation(new Vector3(-0.5f, -0.5f, 0))
        * Matrix.CreateScale(300)
        * Matrix.CreateTranslation(-Vector3.UnitZ);
    effect.Projection = Matrix.CreateOrthographic(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 1, 10000);
    effect.View = Matrix.CreateLookAt(Vector3.UnitZ, Vector3.Zero, Vector3.UnitY);
    var grassVertices = new[]
    {
        new VertexPositionColorTexture(Vector3.Zero, new Color(1f, 1f, 1f, 1f), Vector2.Zero),
        new VertexPositionColorTexture(Vector3.UnitY, new Color(1f, 1f, 1f, 1f), Vector2.UnitY),
        new VertexPositionColorTexture(new Vector3(1, 1, 0), new Color(1f, 1f, 1f, 1f), Vector2.One),
        new VertexPositionColorTexture(Vector3.Zero, new Color(1f, 1f, 1f, 1f), Vector2.Zero),
        new VertexPositionColorTexture(new Vector3(1, 1, 0), new Color(1f, 1f, 1f, 1f), Vector2.One),
        new VertexPositionColorTexture(Vector3.UnitX, new Color(1f, 1f, 1f, 0f), Vector2.UnitX),
    };
    effect.Texture = grassTexture;
    effect.Techniques[0].Passes[0].Apply();
    GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, grassVertices, 0, 2);
    var snowVertices = new[]
    {
        new VertexPositionColorTexture(Vector3.Zero, new Color(1f, 1f, 1f, 0f), Vector2.Zero),
        new VertexPositionColorTexture(Vector3.UnitY, new Color(1f, 1f, 1f, 0f), Vector2.UnitY),
        new VertexPositionColorTexture(new Vector3(1, 1, 0), new Color(1f, 1f, 1f, 0f), Vector2.One),
        new VertexPositionColorTexture(Vector3.Zero, new Color(1f, 1f, 1f, 0f), Vector2.Zero),
        new VertexPositionColorTexture(new Vector3(1, 1, 0), new Color(1f, 1f, 1f, 0f), Vector2.One),
        new VertexPositionColorTexture(Vector3.UnitX, new Color(1f, 1f, 1f, 1f), Vector2.UnitX),
    };
    effect.Texture = snowTexture;
    effect.Techniques[0].Passes[0].Apply();
    GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, snowVertices, 0, 2);
