    abstract class Drawable
    {
        public abstract Vector2 DrawPosition { get; }
        public abstract Texture2D Texture { get; }
        public abstract float Rotation { get; }
        public abstract Vector2 Origin { get; }
        public abstract Vector2 Scale { get; }
        public abstract bool FlipHorizontally { get; }
        public abstract Vector2[] Vertices { get; }
        public Matrix TransformationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-new Vector3(Width / 2, 0, 0))
                    * Matrix.CreateScale(new Vector3(FlipHorizontally ? -1 : 1, 1, 1))
                    * Matrix.CreateTranslation(new Vector3(Width / 2, 0, 0))
                    * Matrix.CreateTranslation(-new Vector3(Origin, 0))
                    * Matrix.CreateScale(new Vector3(Scale, 0))
                    * Matrix.CreateRotationZ(Rotation)
                    * Matrix.CreateTranslation(new Vector3(DrawPosition, 0));
            }
        }
    }
    class Camera
    {
        private readonly Viewport viewport;
        public Matrix GetViewMatrix()
        {
            return Matrix.CreateScale(1, -1, 1) * Matrix.CreateTranslation(0, viewport.Height, 0);
        }
        public Vector2 MouseToWorld(int x, int y)
        {
            return Vector2.Transform(new Vector2(x, y), Matrix.CreateScale(1, -1, 1) * Matrix.CreateTranslation(0, viewport.Height, 0));
        }
    }
    class Game1 : Microsoft.Xna.Framework.Game
    {
        private Drawable avatar;
        private Camera camera;
        ...
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix());
            spriteBatch.Draw(avatar.Texture, avatar.DrawPosition, new Rectangle(0, 0, avatar.Texture.Width, avatar.Texture.Height), Color.White, avatar.Rotation, avatar.Origin, avatar.Scale, avatar.FlipHorizontally ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            spriteBatch.End();
            basicEffect.CurrentTechnique.Passes[0].Apply();
            VertexPositionColor[] vertices = new VertexPositionColor[avatar.Vertices.Length + 1];
            Matrix m = MakeAffineTransform(avatar);
            for (int i = 0; i < avatar.Vertices.Length; i++)
            {
                vertices[i] = new VertexPositionColor(Vector3.Transform(new Vector3(Vector2.Transform(avatar.Vertices[i], m), 0), camera.GetViewMatrix()), Color.Black);
                Console.WriteLine(vertices[i]);
            }
            vertices[vertices.Length - 1] = vertices[0];
            graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, vertices, 0, vertices.Length - 1);
            base.Draw(gameTime);
        }
        ...
    }
