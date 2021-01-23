    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    namespace PlanetDefence
    {
        class Battleship
    {
        //Textures
        Texture2D playerBattleshipTexture;
        //Rectangles
         Rectangle playerBattleshipRectangle;
        //Integers
        public Battleship(Texture2D newPlayerBattleshipTexture, Rectangle newPlayerBattleshipRectangle)
        {
            playerBattleshipTexture = newPlayerBattleshipTexture;
            playerBattleshipRectangle = newPlayerBattleshipRectangle;
            newPlayerBattleshipRectangle = new Rectangle(100, 100, 100, 100);
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the player Battleship
            spriteBatch.Draw(playerBattleshipTexture, playerBattleshipRectangle, Color.White);
        }
    }
