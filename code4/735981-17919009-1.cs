    void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            tm.Stop();
            tm.Start();
            // Reseting the time back to original. Here I have assumed that original one is Arrow.
            this.Dispatcher.Invoke(new Action(() =>
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }));
        }
        void tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (Mouse.OverrideCursor != Cursors.None)
                {
                    Mouse.OverrideCursor = Cursors.None;
                    currentCursor = Mouse.OverrideCursor;
                }
            }));
        }
