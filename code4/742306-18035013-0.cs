     public class ImageViewModel : ViewModelBase
        {
            ImageSource _source;
            public ImageSource Source
            {
                get { return _source; }
                set
                {
                    _source = value;
                    OnPropertyChanged("Source");
                }
            }
            public ImageViewModel()
            {
                //Initialize Source using new bitmap or any other way
            }
        }
