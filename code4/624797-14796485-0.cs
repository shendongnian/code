	// These three lines are required if you use SpriteBatch, to reset some of its states
	GraphicsDevice.BlendState = BlendState.Opaque;
	GraphicsDevice.DepthStencilState = DepthStencilState.Default;
	GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
	// Transform your model to place it somewhere in the world
	basicEffect.World = Matrix.CreateRotationZ(MathHelper.PiOver4); // for sake of example
	// Transform the entire world around (effectively: place the camera)
	basicEffect.View = Matrix.CreateLookAt(new Vector3(0, 0, -3), Vector3.Zero, Vector3.Up);
	// Specify how 3D points are projected/transformed onto the 2D screen
	basicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45),
			(float)GraphicsDevice.Viewport.Width / (float)GraphicsDevice.Viewport.Height, 1.0f, 100.0f);
	// Tell BasicEffect to make use of your vertex colors
	basicEffect.VertexColorEnabled = true;
	// I'm setting this so that *both* sides of your triangle are drawn
	// So it won't be back-face culled if you move it or the camera around behind it
	GraphicsDevice.RasterizerState = RasterizerState.CullNone;
	// Render with a BasicEffect that was created in LoadContent
	// (BasicEffect only has one pass - but effects in general can have many rendering passes)
	foreach(EffectPass pass in basicEffect.CurrentTechnique.Passes)
	{
		// This is the all-important line that sets the effect, and all of its settings, on the graphics device
		pass.Apply();
		// Here's your code:
		VertexPositionColor[] vertices = new VertexPositionColor[3];
		vertices[0].Position = new Vector3(-0.5f, -0.5f, 0f);
		vertices[0].Color = Color.Red;
		vertices[1].Position = new Vector3(0, 0.5f, 0f);
		vertices[1].Color = Color.Green;
		vertices[2].Position = new Vector3(0.5f, -0.5f, 0f);
		vertices[2].Color = Color.Yellow;
		GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices, 0, 1);
	}
