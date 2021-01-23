    private void draw(int args)
        {
            parent.Children.Clear();
    
            List<MyCanvas> children = fetchManyChildren(100);
            Random rand = new Random();
    
            foreach (MyCanvas child in children)
            {
                while(true)
                {
                    // Choose a random place on Canvas we would like to place child
                        
                    child.xPos = nextDouble(rand, 0, parent.ActualWidth - child.Width);
                    child.yPos = nextDouble(rand, 0, parent.ActualHeight - child.Height);
                
                    // Now see if it collides with ones already on Canvas
                
                    bool bCollisionDetected = false;
                    
                    foreach (MyCanvas sibling in parent.Children)
                    {
                        bCollisionDetected = child.collidesWith(sibling);
                        
                        if (bCollisionDetected)
                            break;
                    }
                    
                    if (!bCollisionDetected) // Was able to place child in free position
                        break;
                }
    
                Canvas.SetLeft(child, child.xPos);
                Canvas.SetTop(child, child.yPos);
    
                parent.Children.Add(child);
            }
        }
