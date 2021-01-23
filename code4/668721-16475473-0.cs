        public void TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DockPanel dp = (DockPanel)sender;
            Window parentWindow = Window.GetWindow(dp);
            doubleClick = IsDoubleClick(sender, e);
            
            if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed && !doubleClick)
            {
                if (parentWindow.WindowState == WindowState.Maximized)
                {
                    setStartPosition(sender, e);
                }
            }
            if (doubleClick)
            {
                if (parentWindow.WindowState == System.Windows.WindowState.Maximized)
                {
                    parentWindow.WindowState = System.Windows.WindowState.Normal;
                }
                else
                {
                    parentWindow.WindowState = System.Windows.WindowState.Maximized;
                }
            }
        }
        private void TITLEBAR_MouseMove(object sender, MouseEventArgs e)
        {
            DockPanel dp = (DockPanel)sender;
            Window parentWindow = Window.GetWindow(dp);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (IsDragging(sender, e) && !doubleClick)
                {
                    if (parentWindow.WindowState == WindowState.Maximized)
                    {
                        double mouseX = e.GetPosition(parentWindow).X;
                        double width = parentWindow.RestoreBounds.Width;
                        System.Drawing.Rectangle screenBounds = getCurrentScreenBounds(parentWindow);
                        double x = screenBounds.Left + (mouseX - ((width / 100.00) * ((100.00 / screenBounds.Width) * mouseX)));
                        if (x < 0)
                        {
                            x = 0;
                        }
                        else
                        {
                            if (x + width > screenBounds.Left + screenBounds.Width)
                            {
                                x = screenBounds.Left + screenBounds.Width - width;
                            }
                        }
                        parentWindow.Left = x;
                        parentWindow.Top = screenBounds.Top;
                        parentWindow.WindowState = System.Windows.WindowState.Normal;
                    }
                    parentWindow.DragMove();
                }
            }
        }
