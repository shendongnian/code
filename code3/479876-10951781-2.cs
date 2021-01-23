        private BasicEffect mBasicEffect;
        public void Draw(GraphicsDevice graphicsDevice)
        {
            // If we haven't set this up yet then do so now
            if (mBasicEffect == null)
            {
                CreateBasicEffect(graphicsDevice);
            }
            foreach (EffectPass pass in mBasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                int num = mCorners.Length + 1;
                short[] triangleStripIndices = new short[num];
                VertexPositionColor[] primitiveList = new VertexPositionColor[num];
                for (int i = 0; i < num; ++i)
                {
                    int index = i % mCorners.Length;
                    Vector2 vec = mCorners[index];
                    primitiveList[index] = new VertexPositionColor(new Vector3(vec, 0), Color.White);
                    triangleStripIndices[i] = (short)i;
                }
                graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, primitiveList, 0, 5, triangleStripIndices, 0, 4);
            }
        }
        private void CreateBasicEffect(GraphicsDevice device)
        {
            mBasicEffect = new BasicEffect(device);
            mBasicEffect.VertexColorEnabled = true;
            Matrix viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 1), Vector3.Zero, Vector3.Up);
            Matrix worldMatrix = Matrix.CreateTranslation(0, 0, 0);
            Matrix projectionMatrix = Matrix.CreateOrthographicOffCenter(0, device.Viewport.Width, device.Viewport.Height, 0, 1, 1000);
            mBasicEffect.World = worldMatrix;
            mBasicEffect.View = viewMatrix;
            mBasicEffect.Projection = projectionMatrix;
        }
