    static Direction VectorToDirection(Vector2 direction)
    {
        var mappings = new[]
        {
            new { Direction = Direction.Up, Axis = -Vector2.UnitY },
            new { Direction = Direction.Down, Axis = Vector2.UnitY },
            new { Direction = Direction.Left, Axis = -Vector2.UnitX },
            new { Direction = Direction.Right, Axis = Vector2.UnitX }
        };
        return mappings.OrderBy(m => Math.Acos(Vector2.Dot(direction, m.Axis))).Select(m => m.Direction).First();
    }
