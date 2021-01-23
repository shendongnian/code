    if (isSaveBox)
    {
        //Get the current keyboard state and keys that are pressed
        KeyboardState keyboardState = Keyboard.GetState();
        Keys[] keys = keyboardState.GetPressedKeys();
        foreach (Keys currentKey in keys)
        {
            if (currentKey != Keys.None)
            {
                //If we have pressed the same key twice, wait atleast 125ms before adding it again
                if (lastKeys.Contains(currentKey))
                {
                    if ((gameTime.TotalGameTime.TotalMilliseconds - timer > 125))
                        HandleKey(gameTime, currentKey);
                }
                //If we press a new key, add it
                else if (!lastKeys.Contains(currentKey))
                    HandleKey(gameTime, currentKey);
            }
        }
        //Save the last keys and pressed keys array
        lastKeyboardState = keyboardState;
        lastKeys = keys;
    }
