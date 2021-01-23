    public partial class MediaPlayerControlMain : Window,INotifyPropertyChanged
        {
            
            public MediaPlayerControlMain()
            {                
                InitializeComponent();
                MediaPlayerMain = new MediaPlayerMain();
            }
            private MediaPlayerMain mediaPlayerMain;
            public MediaPlayerMain MediaPlayerMain
            {
                get { return mediaPlayerMain; }
                set { mediaPlayerMain = value; Notify("MediaPlayerMain"); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void Notify(string propName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
            
            }
        }
     "{Binding MediaPlayerMain RelativeSource={RelativeSource AncestorType=Window}}"
