    while (!done)
    {
        // Try to connect with a reasonable ReceiveTimeout
        connected = EstablishTheConnectionAndHandleAnyException();
        if (connected)
        {
            // Do useful work
            done = true;
        }
        else
        {
            // Receive timeout
            // If interactive, give the user an opportunity to abort
            //    by setting done = true
            // At least log the situation
        }
    }
