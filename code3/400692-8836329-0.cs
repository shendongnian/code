    private DispatcherTimer CursorTimer { get; set; }
    private DateTime CursorLastMoveTime { get; set; }
    
    void CursorTimer_Tick(object sender, EventArgs e)
            {
                TimeSpan delta = DateTime.Now.Subtract(this.CursorLastMoveTime);
                if (delta.TotalSeconds > 3)
                {
                    CursorTimer.Stop();
                    Mouse.OverrideCursor = Cursors.None;
                }
            }
    
    
    private void Window_MouseMove(object sender, MouseEventArgs e)
            {
                #region Hide/Show cursor over the main window
                Mouse.OverrideCursor = Cursors.Arrow;
                CursorLastMoveTime = DateTime.Now;
                if (CursorTimer.IsEnabled == false)
                    CursorTimer.Start();
                #endregion
            }
