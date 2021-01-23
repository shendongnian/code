     protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                
                for (int i = 0; i < mRayPos.Length ; i++)
                {
                    // This is the line that moves the triangle along your ray.
                    mEffect.World = Matrix.CreateTranslation(new Vector3(mRayPos[i].X, mRayPos[i].Y, mRayPos[i].Z));
                    mEffect.Techniques[0].Passes[0].Apply();
    
                    // These lines tell the graphics card that you want to draw your triangle.
                    GraphicsDevice.SetVertexBuffer(triangleVertexBuffer);
                    GraphicsDevice.Indices = triangleIndexBuffer;
                    GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 3, 0, 1);
                }
    
                base.Draw(gameTime);
            }
