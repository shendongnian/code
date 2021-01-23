    // define movement vector as +4 units in 'Y' axis
    // rotated by player facing
    Point2D MoveVector = new Point2D(0, 4).Rotate(Player.FacingAngle);
    // adjust player position by movement vector:
    Player.Position.Add(MoveVector);
