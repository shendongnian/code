        public int Width 
        {
            get { return width; }
            set 
              {
                if(width != value)
                  {
                     width = value;
                     NotifyPropertyChanged();
                  }
              }
        }
