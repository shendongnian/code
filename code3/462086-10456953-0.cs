    static RasterizerState rs = new RasterizerState() { FillMode = FillMode.Wireframe; }
       
    protected override void Draw(GameTime gameTime)
    {
        CreateMesh();
        GraphicsDevice.Clear(Color.SkyBlue);
        GraphicsDevice.RasterizerState = rs;
        
        effect.Parameters["View"].SetValue(cam.viewMatrix);
        effect.Parameters["Projection"].SetValue(projectionMatrix);
        effect.CurrentTechnique = effect.Techniques["Technique1"];
        effect.CurrentTechnique.Passes[0].Apply();
        GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, vertices.Count, 0, indices.Length / 3);
        ....
