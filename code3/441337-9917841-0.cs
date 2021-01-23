    if (playersp.Y > screenHeight  /4) {
      int newX = (int) playersp.X;
      int newY = (int) playersp.Y-1;
      if (isMovable(map[newX, newY])) {
        playersp.Y = newY;
      }
    } else {
      ScrollUp();
    }
    public static bool isMovable(int tile)
    {
      if (tile == 4 || tile == 8) {
        return false;
      }
      return true;
    }
