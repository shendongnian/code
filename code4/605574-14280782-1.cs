        public delegate void MyDelegate();
        public void Refresh()
        {
            //this.Refresh();
              this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, (MyDelegate) delegate() { });        
        }
