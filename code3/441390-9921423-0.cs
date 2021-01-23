    public static Vector2 GetGridCoordinates(MouseState mouseState, int gridSize){
        return new Vector2(
            (int)Math.Floor(mouseState.X / gridSize),
            (int)Math.Floor(mouseState.Y / gridSize)
        );
    }
