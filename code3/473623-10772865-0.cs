    namespace WpfTest {
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    public partial class MainWindow : Window {
        private readonly TaskScheduler _taskScheduler;
        public MainWindow() {
            InitializeComponent();
            _taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            button.Click += ButtonOnClick;
        }
        public string Text {
            get {
                if (text.CheckAccess()) {
                    return text.Text;
                }
                return Task.Factory.StartNew(
                    () => text.Text, CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
            }
            set {
                if (text.CheckAccess()) {
                    text.Text = value;
                } else {
                    Task.Factory.StartNew(
                        () => { text.Text = value; }, CancellationToken.None, TaskCreationOptions.None, _taskScheduler);
                }
            }
        }
        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs) {
            Text += "Test1";
            new Thread(() => { Text += "Test2"; }).Start();
        }
    }
    }
