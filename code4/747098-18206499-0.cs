		RenderTarget2D scaleupTarget = null;
		protected override void Draw(GameTime gameTime)
		{                        
				if (scaleupTarget == null)
				{
						// be sure to keep the depthformat when creating the new renderTarget2d
						scaleupTarget = new RenderTarget2D(GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, false, SurfaceFormat.Color, DepthFormat.Depth24);                
				}        
				GraphicsDevice.SetRenderTarget(scaleupTarget);
				GraphicsDevice.Clear(ClearOptions.Target, Color.SeaGreen, 1.0f, 0);
				GraphicsDevice.BlendState = BlendState.Opaque;
				GraphicsDevice.DepthStencilState = DepthStencilState.Default;
				
				// Setup the rasterState, 
				// if CullMode.None; works, try with 
				// CullMode.CullCounterClockwiseFace
				// afterwards
				var rs = new RasterizerState();
				rs.CullMode = CullMode.None;
				rs.FillMode = FillMode.Solid;
				
				// Set the GraphicsDevice to use the new RasterizeState
				GraphicsDevice.RasterizerState = rs;
				
				DrawModel(building_a_mdl, (Matrix.Identity * Matrix.CreateTranslation(100, -14, -100)), building_a_tex);
				scaleupEffect.Parameters["RandomOffset"].SetValue((float)rng.NextDouble());
				GraphicsDevice.Textures[1] = noiseTexture;
				GraphicsDevice.SetRenderTarget(null);
				// SpriteBatch.Begin will set the GraphicsDevice.DepthStencilState to None.
				spriteBatch.Begin(
						SpriteSortMode.Texture,
						BlendState.AlphaBlend,
						SamplerState.PointClamp,
						null,
						null,
						scaleupEffect);
				spriteBatch.Draw(scaleupTarget, Vector2.Zero, null, Color.White, 0.0f, Vector2.Zero, upScaleAmount, SpriteEffects.None, 0.0f);            
				spriteBatch.End();
				
				// Set back to the original depthstate before you continue.
				GraphicsDevice.DepthStencilState = DepthStencilState.Default;
		}
