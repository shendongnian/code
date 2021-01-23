    public void ClickDevelopment()
        {
            Thread.Sleep(10000);
            #region Variable Declarations
            WinClient uIDevelopmentClient = this.UIQualityTrack30Window.UIItemWindow.UIQualityTrack30Client.UIDevelopmentClient;
            #endregion
            // Click 'Development' client
            Mouse.Click(uIDevelopmentClient, new Point(39, 52));
        }
