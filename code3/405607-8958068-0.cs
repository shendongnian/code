        in the constructor register this
        public MainWindow()
        { 
           UpdateColorDelegate += UpdateColorMethod;
        } 
        
        // delegate and event to update color on mainwindow 
        public delegate void UpdateColorDelegate(string colorname);
        public event UpdateColorDelegate updateMainWindow;
        // launches a thread to show viewer
        private void launchViewerThread_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(this.ThreadProc);
            t.Start();
        }
        
        // thread proc
        public void ThreadProc()
        {
           // code for viewer window
           ...
           // if you want to access any main window elements then just call DispatchToMainThread method
           DispatchToUiThread(color);   
        } 
         
        // 
        private void DispatchToUiThread(string color)
        {
          if (updateMainWindow != null)
          {
            object[] param = new object[1] { color};
            Dispatcher.BeginInvoke(updateMainWindow, param);
          }
        }
        
        // update the mainwindow control's from this method
        private void UpdateColorMethod(string colorName)
        {
           // change control or do whatever with main window controls
        } 
