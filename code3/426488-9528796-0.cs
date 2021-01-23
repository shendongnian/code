    using System;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    namespace Physics
    {
    	public class Ship
    	{
    		public Texture2D Texture { get; set; }
    		public Vector2 Position { get; set; }
    		public double Rotation { get; set; }
    		private MouseState currState;
    
    		public Ship(Texture2D texture, Vector2 position)
    		{
    			Texture = texture;
    			Position = position;
    			Rotation = 0;
    		}
    
    		public void Update()
    		{
    			currState = Mouse.GetState();
    
    			var mouseloc = new Vector2(currState.X, currState.Y);
    			Vector2 direction = Position - mouseloc;
    			Rotation = Math.Atan2(direction.Y, direction.X) + MathHelper.PiOver2;
    		}
    
    		public void Draw(SpriteBatch spriteBatch)
    		{
    			spriteBatch.Draw(Texture, Position, null, Color.White, (float) Rotation,
    			                 new Vector2(Texture.Width/2, Texture.Height/2), 0.5f,
    			                 SpriteEffects.None, 0.0f);
    		}
    	}
    }
