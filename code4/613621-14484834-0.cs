    public virtual bool HasCollisionWithAnyActor(Vector2 toCheck)
    {
        // "Easy out": if this actor does not cause collisions then
        // we know that it is not colliding with any actor.
        if (!causingCollision)
          return false;
        Vector2 floored = toCheck.Floor();
        var collidingActors = 
          from actor in GamePlay.actors
          where actor != this
          where actor.causingCollision
          where actor.isAlive
          where GamePlay.IsOnScreen(actor.location)
          where actor.location.Floor() == floored
          select actor;
        return collidingActors.Any();
    }
