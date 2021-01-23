    bool collision=false;
    foreach (CollisionTiles tile in map.CollisionTiles) {
            if(personRectangle.Intersects(tile.Rectangle)) {
                 collision =true;
            }
    }
