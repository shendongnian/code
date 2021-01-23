    public class Paddle : DrawableGameComponent
    {
        private readonly VertexPositionColor[] _vertices = new VertexPositionColor[6];
        private readonly float _width;
        private readonly float _height;
        private IndexBuffer _indexbuffer;
        private VertexBuffer _vertexbuffer;
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }
        public float Speed { get; set; }
        public Paddle(Game game, float width, float height)
            : base(game)
        {
            _width = width;
            _height = height;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            _vertices[0].Position = new Vector3(0, 0, 0);
            _vertices[0].Color = Color.Red;
            _vertices[1].Position = new Vector3(_width, _height, 0);
            _vertices[1].Color = Color.Green;
            _vertices[2].Position = new Vector3(0, _height, 0);
            _vertices[2].Color = Color.Blue;
            _vertices[3].Position = new Vector3(_width, 0, 0);
            _vertices[3].Color = Color.Green;
            _vertexbuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), _vertices.Length, BufferUsage.WriteOnly);
            _vertexbuffer.SetData(_vertices);
            var indices = new short[6];
            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;
            indices[3] = 0;
            indices[4] = 3;
            indices[5] = 1;
            _indexbuffer = new IndexBuffer(GraphicsDevice, typeof(short), 6, BufferUsage.WriteOnly);
            _indexbuffer.SetData(indices);
        }
        public BoundingBox GetBoundingBox()
        {
            return new BoundingBox(Position, Position + new Vector3(_width, _height, 0));
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.SetVertexBuffer(_vertexbuffer);
            GraphicsDevice.Indices = _indexbuffer;
            GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 4, 0, 2);
        }
    }
