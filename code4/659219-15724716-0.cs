    class AnimatedObject
    {
        Texture2D texture;
        Rectangle currentRectangle;
        Rectangle frameSize;
        int frameCount;
        int currentFrame;
        bool isRunning;
        public AnimatedObject(Texture2D lTexture, Rectangle lFrameSize, int lFrameCount)
        {
            texture = lTexture;
            frameSize = lFrameSize;
            currentRectangle = lFrameSize;
            currentFrame = 0;
        }
        public void Pause()
        {
            isRunning = false;
        }
        public void Resume()
        {
            isRunning = true;
        }
        public void Restart()
        {
            currentFrame = 0;
            isRunning = true;
        }
        public void Update()
        {
            if(isRunning)
            {
                ++currentFrame;
                if(currentFrame == frameCount)
                {
                    currentFrame = 0;
                }
                currentRectangle.X = frameSize.Width * currentFrame;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(isRunning)
            {
                spriteBatch.Draw(texture, currentRectangle, Color.White);
            }
        }
    }
