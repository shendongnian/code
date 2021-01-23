    private bool collision(Rectangle object1, Color[,] dataA, Rectangle object2, Color[,] dataB)
        {
    	
    	var  RotatedP0=  new Vector2.Transform( new Vector2( object2.Top,object2.Left ),Matrix.CreateRotationZ(theta));
    	var  RotatedP1=  new Vector2.Transform( new Vector2 (object2.Bottom,object2.Right),Matrix.CreateRotationZ(theta ) ); 	
    	
    	
            if (object1.Bottom < RotatedP0.Y)
                return perPixel(object1, dataA, object2, dataB);
           if (object1.Top > RotatedP1.Y)
               return perPixel(object1, dataA, object2, dataB);
           if (object1.Left > RotatedP1.X)
               return perPixel(object1, dataA, object2, dataB);
           if (object1.Right < RotatedP0.X)
               return perPixel(object1, dataA, object2, dataB);
    
           return true;
        }
    
        private bool perPixel(Rectangle object1, Color[,] dataA, Rectangle object2, Color[,] dataB)
        {
            //Bounds of collision
            int top = Math.Max(object1.Top, object2.Top);
            int bottom = Math.Min(object1.Bottom, object2.Bottom);
            int left = Math.Max(object1.Left, object2.Left);
            int right = Math.Min(object1.Right, object2.Right);
    
            //Check every pixel
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
    				
                    Color colourA = dataA[x, y];
    				
    				Vector2 v = Vector2.Transform(new Vector2(x,y), Matrix.CreateRotationZ(theta));
    				
                    Color colourB = dataB[ (int) v.X, (int) v.Y];
    
                    if (colourA.A != 0 && colourB.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
 
