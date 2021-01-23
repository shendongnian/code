    public Vector2 GetNextSquare(bool down, bool left, Vector2 position)  
    {
        int x = (int)position.X;
        int y = (int)position.Y;
    //...other code
       if (blockColors[board[next_y, next_x]] == Color.Green)
       {
          //End
       }
       else if (board[next_y, next_x] == 0)
       {
            return new Vector2(x, y);
       }
       else
       {
            return new Vector2(next_x, next_y);
       }
    }
