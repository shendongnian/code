    public class MyRow : INotifyPropertyChanged
    {
        public event PropertyChanged;
    
        private string _stringValue = string.Empty;
        public string StringValue
        {
            get { return _stringValue; }
            set
            {
                if( _stringValue != value )
                {
                    _stringValue = value;
                    if( PropertyChanged != null )
                    {
                        PropertyChanged( this, new PropertyChangedEventArgs( "StringValue" ) );
                    }
                 }
            }
        }
    
        // continue with the rest of your properties
    }
