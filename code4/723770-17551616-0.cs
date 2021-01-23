      public void WrapLengthyWork(Action lengthyWork)
        {
            SetWaiting(true);
            System.Windows.Forms.Application.DoEvents();
            lengthy(); 
            SetWaiting(false);
        }
    
        public void SetWaiting(bool wait)
        {
            if (wait == true)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                Application.Current.MainWindow.IsEnabled = false;
           }
            else
            {
                IsEnabled = true;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }
