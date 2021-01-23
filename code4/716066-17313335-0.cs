                TouchCollection touchcollection = TouchPanel.GetState();
                foreach (TouchLocation t1 in touchcollection)
                {
                    if (t1.State == TouchLocationState.Pressed)
                    {
                        Vector2 touchposition = t1.Position;
                        if (touchposition.X >= (position.X + texture.Width))
                            velocity.X = 3f;
                        else if (touchposition.X <= position.X)
                            velocity.X = -3f;
                        else
                            velocity.X = 0;
    
                        if (touchposition.Y < position.Y && hasjumped == false)
                        {
                            position.Y -= 10f;
                            velocity.Y = -5f;
                            hasjumped = true;
                        }
                    }
                }
    
                if (hasjumped == true)
                {
                    velocity.Y += 1.5f;
                }
                if (position.Y + texture.Height > 790)
                    hasjumped = false;
    
                if (hasjumped == false)
                    velocity.Y = 0;
    
                position += velocity;
