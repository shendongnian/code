    private TimeSpan timeToWait = TimeSpan.FromMilliseconds(5000); // 5 seconds
    private TimeSpan lastStateCheck;
    public void Update(GameTime gameTime) {
        if (lastStateCheck + timeToWait < gameTime.TotalGameTime) {
            // switch states after 5 seconds..
            /* Switch state code here */
            lastStateCheck = gameTime.TotalGameTime;
        }
    }
