    protected override void Draw(GameTime gameTime)
    {
            
       GraphicsDevice.Clear(Color.CornflowerBlue);
                
       #region ResetGraphic
                
       ResetGraphic();
                
       #endregion
       #region render 3D
       BeginRender3D();
       //Render 3D here
       #endregion
       #region render 2D
                
       //Render 2D here
       #endregion
    
    }
    public void ResetGraphic()
    {              
       GraphicsDevice.BlendState = BlendState.AlphaBlend;
       GraphicsDevice.DepthStencilState = DepthStencilState.None;
       GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
       GraphicsDevice.SamplerStates[0] = SamplerState.AnisotropicWrap;
    }
    public void BeginRender3D()
    {
       GraphicsDevice.BlendState = BlendState.Opaque;
       GraphicsDevice.DepthStencilState = DepthStencilState.Default;
    }
