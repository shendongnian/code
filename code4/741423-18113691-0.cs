    SevenSegmentDisplay myDisplay = new SevenSegmentDisplay(0, 0);
    // Inside the game loop somewhere.
    if (playerScoreCondition) {
        // player.Score++;
        // In this case score is still 0.
        myDisplay.Update(player.Score);    
    }
    // Draw
    myDisplay.Draw(spriteBatch, segmentTexture, scoreDisplayX, scoreDisplayY, Color.White, new Color(30, 30, 30, 255));
