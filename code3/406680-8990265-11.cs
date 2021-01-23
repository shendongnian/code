        private void window_MouseDown(object sender, MouseEventArgs e)
        {
            Dispatcher.BeginInvoke((ThreadStart)delegate()
                {
                    if (window.Content.Equals(msg))
                    {
                        window.Content = new HeavyObject();
                    }
                    else
                    {
                        window.Content = msg;
                    }
                }, DispatcherPriority.ApplicationIdle);
        }
