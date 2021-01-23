    if (IsPressed())
    {
        // Key has just been pushed
        if (!WasPressed())
        {
            // Store the time
            pushTime = GetCurrentTime();
        
            // Execute the action once immediately
            // like a letter being printed when the button is pressed
            Action();
        }
        // Enough time has passed since the last push time
        if (HasPassedDelay())
        {
            Action();
        }   
    }
