	struct IntVertexPositionTexture : IVertexType
	{
		public Short4 Position;
		public NormalizedShort2 TextureCoordinate;
		public IntVertexPositionTexture(Short4 position, NormalizedShort2 textureCoordinate)
		{
			this.Position = position;
			this.TextureCoordinate = textureCoordinate;
		}
		public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[]
		{
			new VertexElement(0, VertexElementFormat.Short4, VertexElementUsage.Position, 0),
			new VertexElement(8, VertexElementFormat.NormalizedShort2, VertexElementUsage.TextureCoordinate, 0),
		});
		VertexDeclaration IVertexType.VertexDeclaration
		{
			get { return IntVertexPositionTexture.VertexDeclaration; }
		}
	}
