    //some usings...
    namespace DispatcherSample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private int _counter = 0;
    
            public MainWindow()
            {
                InitializeComponent();
                this.UpdateBox();
            }
    
            private void manualLockClick(object sender, RoutedEventArgs e)
            {
                _counter++;
                this.UpdateBox();
            }
    
            // runs on the UI thread will lock all updates until done
            private void uiLockClick(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 5; i++)
                {
                    _counter++;
                    this.UpdateBox();
                    Thread.Sleep(1000);
                }
            }
    
            //runs on a background thread, dispatches to UI thread for updates of controls only
            private void dispatchedClick(object sender, RoutedEventArgs e)
            {
                Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            _counter++;
                            this.Dispatcher.Invoke(new Action(() => this.UpdateBox()));
                            Thread.Sleep(1000);
                        }
                    });
            }
    
            private void UpdateBox()
            {
                textBox.Text = _counter.ToString();
            }
        }
    }
