	class Blob
	{
		public Texture2D texture;
		public Dictionary<byte, Color> blobType = new Dictionary<byte, Color>() { { 1, Color.White } };
		public Vector2 position;
		private float scale = 1;
		public float Scale
		{
			get { return scale; }
			set { scale = value; }
		}
		public Blob(Texture2D texture, float scale)
		{
			this.texture = texture;
			this.Scale = scale;
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
		}
	}
