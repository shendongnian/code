    private bool CheckJumpObstacle(Type type)
    {
        return GameItems.Where(x => x != null && type.IsAssignableFrom(x.GetType()))
                        .Any();
    }
