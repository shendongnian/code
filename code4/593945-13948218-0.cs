    public bool? GetCollision(int x, int y)
    {
        bool? isPassable;
        if (x < 0 || x >= 20)
        {
            isPassable = false;
        }
        if (y < 0 || y >= 20)
        {
            isPassable = true;
        }
        return isPassable;
    }
