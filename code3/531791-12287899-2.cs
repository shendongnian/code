    class MyClass:INotifyPropertyChanged
    {
        string shortCutText="Alt+A";
        public string ShortCutText
        {
             get { return shortCutText; } 
             set 
                 { 
                      shortCutText=value; 
                      NotifyPropertyChanged("ShortCutText");
                 }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged( string props )
        {
            if( PropertyChanged != null ) 
                PropertyChanged( this , new PropertyChangedEventArgs( prop ) );
        }
    }
