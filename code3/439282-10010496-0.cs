    if(jumping)
    {
        //Modify our y value based on a bleedoff
        //Eventually this value will be minus so we will start falling.
        position.Y += bleedOff;
        bleedOff -= 0.03f;
        //We should probably stop falling at some point, preferably when we reach the ground.
        if(position.Y <= ground.Y)
        {
            jumping = false;
        }
    }
    
    bleedOff = MathHelper.Clamp(bleedOff, -1f, 1f);
