    bool Collides (Entity p, Entity e) {
        bool noCollisionX = (p.X + p.W < e.X) || (e.X + e.W < p.X);
        bool collisionX = !noCollisionX;
        bool noCollisionY = (p.Y + p.H < e.Y) || (e.Y + e.H < p.Y);
        bool collisionY = !noCollisionY;
        // intersect on BOTH axis.
        return collisionX && collisionY;
     }
