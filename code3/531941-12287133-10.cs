        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged( string prop )
        {
            if( PropertyChanged != null ) 
            PropertyChanged( this , new PropertyChangedEventArgs( prop ) );
        }
    }
    public class MyObject
    {
        public string MyField{get;set;}
    }
