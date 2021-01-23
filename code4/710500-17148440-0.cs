    sb.End(); // Sets blend state
    BlendState previousState = GraphicsDevice.BlendState; // Retrieve it
    sb.Begin(SpriteSortMode.Immediate, bsSubtract);
    // (...drawing drawing blah...)
    sb.End();
    sb.Begin(SpriteSortMode.Immediate, previousState); // Re-use it
