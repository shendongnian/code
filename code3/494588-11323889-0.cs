    void Moved(Coordinate oldCoordinate, Coordinate newCoordinate) 
    { 
      if (newCoordinate.Intersects(this.Location))
      {
        DamagePlayer(50); 
      }
    } 
