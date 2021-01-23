        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            float rotate = 45f;
            Matrix rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(rotate));
            Vector3 pos1 = Vector3.Transform(new Vector3(0, texture.Width, 0), rotation);
            Vector3 pos2 = Vector3.Transform(new Vector3(0, texture.Height, 0), rotation);
            BoundingBox box = BoundingBox.CreateFromPoints(new Vector3[] { pos1, pos2 });
            float scaleX = this.graphics.PreferredBackBufferWidth / Math.Abs(box.Max.X - box.Min.X);
            float scaleY = this.graphics.PreferredBackBufferHeight / Math.Abs(box.Max.Y - box.Min.Y);
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
            }
            effect.Projection = Projection;
            effect.View = View;
            effect.World = Matrix.CreateScale(scaleX, scaleY, 1f) * rotation;
            effect.Texture = texture;
            GraphicsDevice.Indices = bufferIndex;
            GraphicsDevice.SetVertexBuffer(bufferVertex);
            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 4, 0, 2);
            base.Draw(gameTime);
        }
