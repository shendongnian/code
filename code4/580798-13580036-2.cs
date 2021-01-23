    using System.Windows;
    namespace DataGridTest
    {
    using System;
    using System.ComponentModel;
    using System.Windows.Threading;
    public class Person : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (this._id == value)
                    return;
                this._id = value;
                this.OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (this._name == value)
                    return;
                this._name = value;
                this.OnPropertyChanged("Name");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += this._timer_Tick;
            _timer.Start();
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            var vm = this.DataContext as MainWindowViewModel;
            if(vm != null)
                vm.Refresh();
        }
    }
    }
