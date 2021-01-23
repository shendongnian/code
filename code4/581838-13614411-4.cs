     using System;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    namespace YourNameSpace
    {
        class Game
        {
            //"Global" array for the map, this holds each tile
            Color[,] tiles = new Color[LEVEL_WIDTH, LEVEL_HEIGHT];
            protected override void Initialize() //OR wherever you load the map and stuff
            {
                //Load the texture from the content pipeline
                Texture2D texture = Content.Load<Texture2D>("Your Texture Name and Directory");
    
                //Convert the 1D array, to a 2D array for accessing data easily (Much easier to do Colors[x,y] than Colors[i],because it specifies an easy to read pixel)
                Color[,] Colors = TextureTo2DArray(texture);
            }
            Color[,] TextureTo2DArray(Texture2D texture)
            { //ADD THE REST, I REMOVED TO SAVE SPACE
            }
        }
    }
       
