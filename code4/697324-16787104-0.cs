    public int setPositionY(int newPositionY)
    {
        positionY = newPositionY;
        return positionY;
    }
    public int setSpeedY(int newSpeedY)
    {
        speedY = newSpeedY;
        return speedY;
    }
    positionY = setPositionY(/*new position*/) + setSpeedY(/*new speed*/);
