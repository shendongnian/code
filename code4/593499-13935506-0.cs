        BackgroundWorker _bw;
        bool _returnValue = false;
        private void button_Click(object sender, RoutedEventArgs e)
        {  // if starting the processing by clicking a button
            _bw = new BackgroundWorker();
            IsBusy = true;
            _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.RunWorkerAsync();
        }
        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsBusy = false;
            // retrieve the result of the operation in the _returnValue variable
        }
        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            _returnValue = UnloadData();
        }
        private bool UnloadData()
        {
            if (...)
            {
                LaunchTimeConsumingMethod();
                return true;
            }
            else
                return false;
            //etc ...
        }
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsBusy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register( ... )
