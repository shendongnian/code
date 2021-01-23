    class SomeClass
    {
        static void CurrentFunc()
        {
            var someClass = new SomeClass();
            someClass.NewFunc();
        }
    
        private void NewFunc()
        {
            Window window = FindWindow(windowId);
            if (window == null)
            {
                window = new Window();
                window.Closing += new System.ComponentModel.CancelEventHandler(window_Closing);
                window.Closed += new EventHandler(window_Closed);
                _winDict.Add(windowId, window);
            }
            window.Owner = Application.Current.MainWindow;
            window.Title = title;
            window.Content = guc;
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.ResizeMode = ResizeMode.NoResize;
            window.ShowInTaskbar = false;
        }
    
        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    
        private void window_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
