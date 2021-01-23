    private float mayhitTop()
        {
            //remember that the y coordinate goes downwards so we have to add
            float playersBotCoordinate = Player.Position.Y + Player.Sprite.Height;
            //the y position is the top so nothing to change
            float blocksTopCoordinate = Block.Position.Y;
            hitTop=true; //this is a global variable you have 1 for each direction
            return Math.Abs(playersBotCoordinate - blocksTopCoordinate);
        }
