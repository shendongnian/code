        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            effect = new BasicEffect(GraphicsDevice) { TextureEnabled = true };
            texture = Content.Load<Texture2D>("image");
            Projection = Matrix.CreateOrthographic(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, -10000f, 10000f);
            // Or this one
            //View = Matrix.CreateLookAt(Vector3.Zero, new Vector3(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2, 0), Vector3.UnitY);
            View =
                Matrix.CreateScale(1.0f) *
                Matrix.CreateRotationY(MathHelper.ToRadians(0)) *
                Matrix.CreateRotationX(MathHelper.ToRadians(90)) *
                Matrix.CreateTranslation(0, 0, 0);
            VertexPositionTexture[] vertices = new VertexPositionTexture[4];
            vertices[0] = new VertexPositionTexture(new Vector3(-(texture.Width / 2), 0, -(texture.Width / 2)), new Vector2(0, 1));
            vertices[1] = new VertexPositionTexture(new Vector3((texture.Width / 2), 0, -(texture.Width / 2)), new Vector2(1, 1));
            vertices[2] = new VertexPositionTexture(new Vector3(-(texture.Width / 2), 0, (texture.Width / 2)), new Vector2(0, 0));
            vertices[3] = new VertexPositionTexture(new Vector3((texture.Width / 2), 0, (texture.Width / 2)), new Vector2(1, 0));
            bufferVertex = new VertexBuffer(GraphicsDevice, VertexPositionTexture.VertexDeclaration, 4, BufferUsage.WriteOnly);
            bufferVertex.SetData(vertices);
            int[] indexs = new int[6] { 0, 1, 2, 2, 1, 3 };
            bufferIndex = new IndexBuffer(GraphicsDevice, IndexElementSize.ThirtyTwoBits, 6, BufferUsage.WriteOnly);
            bufferIndex.SetData(indexs);
        }
