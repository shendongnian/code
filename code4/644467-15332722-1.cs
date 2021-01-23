    foreach(Shape s in currentBlocks)
    {
        for(int x = 0; i < 3)
        {
            for(int y = 0; y < 3; y++)
            {
                if(s.Blocks[x][y])
                {
                    gameGrid.Render(s.Pos.X + x, s.Pos.Y + y);
                }
            }
        }
    }
