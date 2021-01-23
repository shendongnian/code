    protected override void Draw(GameTime gameTime) {
       Stopwatch sw = new Stopwatch();
       sw.Start();
       GraphicsDevice.Clear(Color.CornflowerBlue);
       e.Parameters["texture1"].SetValue(im1);
       e.Parameters["texture2"].SetValue(im2);
       spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, e);
       spriteBatch.Draw(im1,new Vector2(0,0),Color.White);
       spriteBatch.End();
       base.Draw(gameTime);
       sw.Stop();
       Console.WriteLine(sw.ElapsedMilliseconds);
    }
