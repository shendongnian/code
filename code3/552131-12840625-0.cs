    public class ViewModel : INotifyPropertyChanged
    {
        private DateTime _year = DateTime.Now;
        public DateTime Year
        {
            get { return _year; }    // <--- append whatever here or in the setter
            set
            {
                _year = value; 
                
                if( this.PropertyChanged != null )
                {
                    this.PropertyChanged( this, new PropertyChangedEventArgs( "Year" ) );
                }
             }
         }
      ...
    }
