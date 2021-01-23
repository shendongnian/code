    public class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MyRowSet> _rowSets = null;
        public ObservableCollection<MyRowSet> RowSets
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
