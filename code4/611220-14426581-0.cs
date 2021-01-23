    public class Contact : INotifyPropertyChanged
    {
        private ContactAvailability _Availability;
        public ContactAvailability Availability
        {
            get { return _Availability; }
            set
            {
                _Availability = value;
                NotifyPropertyChanged("Availability");
                NotifyPropertyChanged("Image");
            }
        }
        public BitmapImage _AvailablePicture;
        public BitmapImage _BusyPicture;
        public BitmapImage Image
        {
            get
            {
                switch (this.Availability)
                {
                    case ContactAvailability.Available:
                        return this._AvailablePicture;
                    case ContactAvailability.Busy:
                        return this._BusyPicture;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
