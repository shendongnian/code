        public BitmapImage Image
        {
            get
            {
                switch (this.Availability)
                {
                    case ContactAvailability.Available:
                        return this._AvailablePicture;
                    case ContactAvailability.Busy:
                        return GetImageWithColorFilter(this._AvailablePicture, Colors.Red);
                    default:
                        throw new NotImplementedException();
                }
            }
        }
