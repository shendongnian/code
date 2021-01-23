    const float jumpHeight = 60F; //arbitrary jump height, change this as needed
    const float jumpHeightChangePerFrame = 10F; //again, change this as desired
    const float gravity = 2F;
    float jumpCeiling;
    bool jumping = false;
    if (Walking == true)
    {
        if (keystate.IsKeyDown(Keys.W))
        {
            jumping = true;
            jumpCeiling = (spritePosition - jumpHeight);
        }
        else //they haven't tried to jump again
        {
            jumping = false; //we set this once there is a collision with the ground, i.e. Walking is true and they've not pressed the jump key again
        }
    }
    if (jumping == true)
    {
        spritePosition -= jumpHeightChangePerFrame;
    }
    //constant gravity of 2 when in the air
    if (Walking == false)
    {
        spritePosition += gravity;
    }
    if (spritePosition < jumpCeiling)
    {
        spritePosition = jumpCeiling;
        jumping = false;
    }
