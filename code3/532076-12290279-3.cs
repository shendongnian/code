    public class MySet : INotifyPropertyChanged
    {
        public event PropertyChanged;
    
        private ObservableCollection<MyRow> _rows = null;
        public ObservableCollection<MyRow> Rows
        {
            get { return _rows; }
            set
            {
                if( _rows != value )
                {
                    _rows = value;
    
                    if( PropertyChanged != null )
                    {
                        PropertyChanged( this, new PropertyChangedEventArgs( "Rows" ) );
                    }
                }
            }
        }
    }
