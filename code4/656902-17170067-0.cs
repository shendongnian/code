    enum CollisionGroup { Bullet, Tree, Player }
    interface ICollider
    {
        CollisionGroup Group { get; }
    }
