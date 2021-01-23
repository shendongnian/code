      Window2 win;
            object locker = new Object();
            private void OnShow(object sender, RoutedEventArgs e)
            {
                lock (locker)
                {
                    if (win == null)
                        win = new Window2();
                    win.Show();
                }
            }
    
            private void OnHide(object sender, RoutedEventArgs e)
            {
                if (win != null)
                    win.Hide();
            }
