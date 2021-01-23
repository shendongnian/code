    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty LoadProperty = DependencyProperty.Register("MyCustom", typeof(bool), typeof(MainWindow), new PropertyMetadata(new PropertyChangedCallback(LoadPropertyChangedCallback)));
        
        public bool Load
        {
            get
            {
                return (bool)this.GetValue(LoadProperty) ;
            }
            set
            {
                this.SetValue(LoadProperty, value);
            }
        }
        static void LoadPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        { 
            //Do your load stuff here
        }
        public MainWindow()
        {
            InitializeComponent();
            this.SetBinding(LoadProperty, new Binding("load"));
            DataContext = new ViewModel();
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            load = true;
        }
        bool m_load;
        public bool load
        {
            get { return m_load; }
            set
            {
                m_load = value;
                OnPropertyChanged("load");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
