        private string _tileColor;
        [Column]
        public string TileColor
        {
            get { return _tileColor; }
            set
            {
                if (_tileColor != value)
                {
                    NotifyPropertyChanging("TileColor");
                    _tileColor = value;
                    NotifyPropertyChanged("TileColor");
                    NotifyPropertyChanged("PeopleId");
                }
            }
        }
        private string _image;
        [Column]
        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    NotifyPropertyChanging("Image");
                    _image = value;
                    NotifyPropertyChanged("Image");
                    NotifyPropertyChanged("PeopleId");
                }
            }
        }
