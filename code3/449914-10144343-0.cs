                for (int y = Game1.LandedBlocks.GetLength(1) - 1; y > 0; y--)
                {
                    for (int CountX = 0; CountX < Game1.LandedBlocks.GetLength(0); CountX++)
                    {
                        Game1.LandedBlocks[CountX, y] = Game1.LandedBlocks[CountX, y - 1];
                    }
                }
