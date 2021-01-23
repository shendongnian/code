    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChanged;
        private ObservableCollection<MySet> _rowSets = null;
        public ObservableCollection<MySet> RowSets
        {
            get { return _rowSets; }
            set
            {
                if( _rowSets != value )
                {
                    _rowSets = value;
                    if( this.PropertyChanged != null )
                    {
                        this.PropertyChanged( this, new PropertyChangedEventArgs( "RowSets" ) );
                    }
                }
            }
        }
    }
