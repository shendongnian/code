    public partial class MainWindow : Window
    {
        UserControl1 ctrl;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Thread winthread = new Thread(new ThreadStart(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(
                        Dispatcher.CurrentDispatcher));
                Window windowObj = new Window();
                Grid gridObj = new Grid();
                ctrl = new UserControl1();
                gridObj.Children.Add(ctrl);
                windowObj.Content = gridObj;
                windowObj.Show();
                System.Windows.Threading.Dispatcher.Run();
            }));
            winthread.IsBackground = true;
            winthread.SetApartmentState(ApartmentState.STA);
            winthread.Start();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ctrl.Dispatcher.Invoke(new Action(() => ctrl.AddStuff()));
        }
    }
