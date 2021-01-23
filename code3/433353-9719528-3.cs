    // The active state from the last frame is now old
    lastMouseState = currentMouseState;
    // Get the mouse state relevant for this frame
    currentMouseState = Mouse.GetState();
    // Recognize a single click of the left mouse button
    if (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
    {
        // React to the click
        // ...
        clickOccurred = true;
    }
