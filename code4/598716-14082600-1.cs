            private void HandleCollisions(CollisionDirection direction)
            {
                // Get the player's bounding rectangle and find neighboring tiles.
                Rectangle bounds = player.GetBoundingBox();
                int leftTile = (int)Math.Floor((float)bounds.Left / Tile.Width);
                int rightTile = (int)Math.Ceiling(((float)bounds.Right / Tile.Width)) - 1;
                int topTile = (int)Math.Floor((float)bounds.Top / Tile.Height);
                int bottomTile = (int)Math.Ceiling(((float)bounds.Bottom / Tile.Height)) - 1;
    
                // Reset flag to search for ground collision.
                isOnGround = false;
    
                // For each potentially colliding tile,
                for (int y = topTile; y <= bottomTile; ++y)
                {
                    for (int x = leftTile; x <= rightTile; ++x)
                    {
                       Rectangle tileBounds = Level.GetBounds(x, y);
                        // If this tile is collidable,
                        bool IsSolid = map.tiles[x,y].IsSolid;
                        Vector2 depth;
                        if (isSolid && TileIntersectsPlayer(BoundingRectangle, tileBounds, direction, out depth))
                        {
                           
                                if ((collision == ItemCollision.Platform && movement.Y > 0))
                                    continue;
                                isOnGround = true;
                                if (isSolid || isOnGround)
                                {
                                    if (direction == CollisionDirection.Horizontal)
                                    {
                                        position.X += depth.X;
                                    }
                                    else
                                    {
    
                                        isOnGround = true;
                                        position.Y += depth.Y;
                                    }
                                }
                            
                           
                        }
                    }
                }
                // Save the new bounds bottom.
                previousBottom = bounds.Bottom;
       
            }
            public static bool TileIntersectsPlayer(Rectangle player, Rectangle block, CollisionDirection direction, out Vector2 depth)
            {
                depth = direction == CollisionDirection.Vertical ? new Vector2(0, player.GetVerticalIntersectionDepth(block)) : new Vector2(player.GetHorizontalIntersectionDepth(block), 0);
                return depth.Y != 0 || depth.X != 0;
            }
