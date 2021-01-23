    		camera = new Camera (graphics.GraphicsDevice);
			effect = new BasicEffect (graphics.GraphicsDevice);
			cubes = new DrawableList<Cube> (this, camera, effect);
			Components.Add (cubes);
			for (int i=0 ; i < 50; i++)
			{
				cubes.Add (new Vector3( i*0.5f, 50.0f, 50.0f), Matrix.Identity, logoTexture);
			}
