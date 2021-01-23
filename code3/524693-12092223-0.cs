        public partial class MainWindow : Window
    {
        OpenFileDialog dlg;
        TranspWnd transpWnd;
        public MainWindow()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Interval = 2500;
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Start();
        }
        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                transpWnd.Close();
            }), null);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            transpWnd = new TranspWnd();
            transpWnd.Visibility = System.Windows.Visibility.Hidden; //doesn't works right
            transpWnd.Show();
            dlg = new OpenFileDialog();
            dlg.ShowDialog(transpWnd);
        }
    }
