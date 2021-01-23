    if (xPos % step == 0)
                {
                    if (!isDescending)
                    {
                        
                        for (int k = 0; k < sprites.Count; k++)
                        {
                            Sprite sprite = sprites[k];
                            sprite.position.X += step;
                        }
    
                        if (bounds.Right == screenWidth || bounds.Left == 0)
                        {
                            touchedRight = !touchedRight;
                            step *= -1;
                        }
    
                        if (!touchedRight) bounds.X += step;
                        if (touchedRight) bounds.X -= step;
                        
                        // for (int k = 0; k < sprites.Count; k++)
                        // {
                        //    Sprite sprite = sprites[k];
    
                        //    bool hitLeft = sprite.position.X == 0;
                        //    bool hitRight = sprite.rect.Right == screenWidth;
                        //    if ((hitLeft) || (hitRight))
                        //    {
                        //        touchedRight = !touchedRight;
                        //        isDescending = true;
                        //    }
                        // }
                    }
