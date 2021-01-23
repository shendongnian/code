    public class DrawableList<T> : DrawableGameComponent
	{
		private BasicEffect effect;
		private Camera camera;
		private class Entity
		{
			public Vector3 Position { get; set; }
			public Matrix Orientation { get; set; }
			public Texture2D Texture { get; set; }
		}
		private Cube cube;
		private List<Entity> entities = new List<Entity>();
		public DrawableList (Game game, Camera camera, BasicEffect effect) 
			: base( game ) 
		{
			this.effect = effect;
			cube = new Cube (game.GraphicsDevice);
			this.camera = camera;
		}
		public void Add( Vector3 position, Matrix orientation, Texture2D texture )
		{
			entities.Add (new Entity() { 
				Position = position,
				Orientation = orientation,
				Texture = texture
			});
		}
		public override void Draw (GameTime gameTime )
		{
			base.Draw (gameTime);
			foreach (var item in entities) {
				
				effect.VertexColorEnabled = false;
				effect.TextureEnabled = true;
				effect.Texture = item.Texture;
				Matrix center = Matrix.CreateTranslation(new Vector3(-0.5f, -0.5f, -0.5f));
				Matrix scale = Matrix.CreateScale(0.05f);
				Matrix translate = Matrix.CreateTranslation(item.Position);
				effect.World = center * scale * translate;
				effect.View = camera.View;
				effect.Projection = camera.Projection;
				cube.Draw (effect);
			}
		}
	}
