    public bool GetCollision(int x, int y)
    {
        bool isPassable = false;
        if (y < 0 || y >= 20)
        {
            isPassable = true;
        }
        return isPassable;
    }
