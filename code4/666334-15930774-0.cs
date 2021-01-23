    //Main Draw function
    public void Draw() {
        //World Coordinates
        spriteBatch.Begin(cameraTransformationMatrix);
        //Draw all world coordinate objects
        //Player, Enemies, Walls, etc.
        spriteBatch.End();
        
        //Screen Coordinates
        spriteBatch.Begin();
        //Draw all screen coordinate objects
        //Menus, In-Game HUD elements, etc.
        spriteBatch.End();
    }
