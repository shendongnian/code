    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainModel();
        }
    }
    
    public class MainModel : INotifyPropertyChanged
    {
        private bool _swapper;
        public bool Swapper
        {
            get { return _swapper; }
            set
            {
                _swapper = value;
                NotifyChanged( "Swapper" );
                SwapContent();
            }
        }
    
        private UserControl _clockView;
        public UserControl ClockView
        {
            get { return _clockView; }
            private set
            {
                _clockView = value;
                NotifyChanged( "ClockView" );
            }
        }
    
        public void SwapContent()
        {
            // AnalogClock and DigitalClock are UserControls
            if( ClockView == null || ClockView.GetType() == typeof( AnalogClock ) )
            {
                ClockView = new DigitalClock();
            }
            else
            {
                ClockView = new AnalogClock();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged( string propName )
        {
            if( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propName ) );
            }
        }
    }
