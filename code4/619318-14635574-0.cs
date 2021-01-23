     private bool hasResolutionChanegd()
        {
            if ((GraphicsDevice.Viewport.Width != ScreenManager.Instance.ScreenWidth) || (GraphicsDevice.Viewport.Height != ScreenManager.Instance.ScreenHeight))
            {
                return true;
            }
            else
            {
               return false;
            }
        }
