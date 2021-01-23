    using System.ComponentModel;
    using Windows.UI.Xaml.Media;
    namespace ImageUserControl
    {
        public class PictureViewModel : INotifyPropertyChanged
        {
            private ImageSource pictureUri;
            public ImageSource PictureUri 
            { 
                get
                {
                    return this.pictureUri;
                }
                set 
                {
                    if (this.pictureUri != value)
                    {
                        this.pictureUri = value;
                        this.RaisePropertyChanged("PictureUri");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(string propertyName)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
