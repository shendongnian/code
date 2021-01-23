    foreach(Spike s in listSpikes){
        if(player.BoundingBox.Intersects(s.BoundingBox)){
            player.DirectionSpeed = Vector.Zero;
        }
    }
