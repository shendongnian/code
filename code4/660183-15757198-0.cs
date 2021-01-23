    if (putoClick.LeftButton == ButtonState.Pressed)
    {
        mouseClick = new Rectangle(putoClick.X, putoClick.Y, 30, 20);
        if (clickArea.Intersects(mouseClick))
        {
            //the button was clicked with the left button
            //so draw the new image and update buttonClicked
            spriteBatch.Draw(imgB, btnPos, Color.White);
            buttonClicked = true;
        }
        else
        {
            spriteBatch.Draw(imgBs, btnPosN, Color.White);
        }
    }
    else if(buttonClicked && putoClick.LeftButton == ButtonState.Released)
    {
        //The button was clicked last frame, but the mouse is now up
        //play the sound!
        btnMenuClickSound.Play();
        
        //the button is no longer clicked
        buttonClicked = false;    
    }
    putoClick = Mouse.GetState(); //also, i presume this needs to be here instead?
