    //this method uses 'orientation' as the current orientation of the ship
    public Vector3 GetForward()
    {
        Matrix rotation = Matrix.CreateFromYawPitchRoll(orientation.Y, orientation.X, orientation.Z);
        return new Vector3(rot.M13, rot.M23, rot.M33);
    }
    //now that you got the appropriate vector
    //you just can move into the direction of this vector like
    Vector3 position = new Vector3(0, 0, 0);
    if(keyState.IsKeyDown(Keys.F))
    {
        position += ship.GetForward();
    }
 
    position *= elapsed;
    
    //update the position of the ship here
