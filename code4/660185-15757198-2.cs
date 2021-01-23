    if (putoClick.LeftButton == ButtonState.Pressed)
    {
        mouseClick = new Rectangle(putoClick.X, putoClick.Y, 30, 20);
        //if the button was clicked with the left mouse button
        //buttonClicked will be true, otherwise false.
        buttonClicked = clickArea.Intersects(mouseClick);
    }
    else if(buttonClicked && putoClick.LeftButton == ButtonState.Released)
    {
        //The button was clicked last frame, but the mouse is now up
        //play the sound!
        btnMenuClickSound.Play(); 
    }
    //the mouse button is released, therefore the button is not clicked
    if(putoClick.LeftButton == ButtonState.Released)
        buttonClicked = false;   
    //draw the appropriate graphic depending on 
    //whether or not the button has been clicked.
    if(buttonClicked)
        spriteBatch.Draw(imgB, btnPos, Color.White);
    else
        spriteBatch.Draw(imgBs, btnPosN, Color.White);
    putoClick = Mouse.GetState(); //also, i presume this needs to be here instead?
