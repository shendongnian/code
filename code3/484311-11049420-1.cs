    #region Using Directives.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    #endregion
    
    namespace sprites
    {
        public class Sprite
        {
            // Texture instances.
            public Texture2D spriteSheet;
            protected Rectangle[] spriteSheetRegions;
            protected Rectangle currentSpriteSheetRegion;
    
            // player instances.
            public Rectangle location;
    
            // call this to change the image that's drawn for the sprite.
            public void SetSpriteSheetIndex(int index)
            {
                currentSpriteSheetRegion = spriteSheetRegions[index];
            }
        }
    
        public class TPlayer : Sprite
        {
            public TPlayer()
            {
                // Since your sprite sheets for the player are fixed we can set them up here.
                spriteSheetRegions = new Rectangle[]
                {
                    new Rectangle (0,0, 50,50),     // standing.
                    new Rectangle (50,0, 100, 50),  // tough walking 1
                    new Rectangle (100,0, 150, 50), // tough walking 2
                };
                currentSpriteSheetRegion = spriteSheetRegions[0];
            }
    
            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(spriteSheet, location, currentSpriteSheetRegion, Color.White);
            }
        }
    
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
    
            List<TPlayer> players;
    
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
    
            protected override void Initialize()
            {
                // Create the players and add 3 of them.
                players = new List<TPlayer>();
                players.Add(new TPlayer() { location = new Rectangle(10, 10, 100, 100) });
                players.Add(new TPlayer() { location = new Rectangle(110, 10, 100, 100) });
                players.Add(new TPlayer() { location = new Rectangle(220, 10, 100, 100) });
    
                base.Initialize();
            }
    
            protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
    
                // Load up the players content.
                Texture2D playerSpriteSheet = Content.Load<Texture2D>("PlayerSpriteSheet");
    
                // each player gets a reference to the same texture so there is no duplication.
                for (int i = 0; i < players.Count; i++)
                    players[i].spriteSheet = playerSpriteSheet;
            }
    
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
    
                // draw the players.
                spriteBatch.Begin();
                for (int i = 0; i < players.Count; i++)
                    players[i].Draw(spriteBatch);
                spriteBatch.End();
    
                base.Draw(gameTime);
            }
        }
    }
