        foreach(Brick b in bricks)
        {
           if(ball.BoundingSphere.Intersects(b.Boundingbox))
           {
               b.Alive=false;
           }
        }
          
