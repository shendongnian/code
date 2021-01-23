    using System.Windows.Threading;
    
    namespace MyWPF App
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime dt;
        DispatcherTimer t;
        public MainWindow()
        {
            InitializeComponent();
            t = new DispatcherTimer();
            t.Tick += new EventHandler(t_Tick);
        }
        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {
            dt=DateTime.Now;
            t.Interval = new TimeSpan(0, 0, 1);
            t.IsEnabled = true;
            
        }
        void t_Tick(object sender, EventArgs e)
        {
            
            if ((DateTime.Now - dt).Seconds >= 5)
            {
                MessageBox.Show("Hello");// Here you can put your code which you want to execute after 5 seconds.
            }
            
        }
        private void button1_MouseLeave(object sender, MouseEventArgs e)
        {
            t.IsEnabled = false;
        }
    }
    }
