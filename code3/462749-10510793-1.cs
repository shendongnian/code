     class ItemVM : INotifyPropertyChanged
    {
        private string TextValue = String.Empty;
        private Brush BackgroundColorValue = null;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public ItemVM(Brush color, string objectData)
        {
            BackgroundColor = color;
            Text = objectData;
        }
        public string Text
        {
            get
            {
                return this.TextValue;
            }
            set
            {
                if (value != this.TextValue)
                {
                    this.TextValue = value;
                    NotifyPropertyChanged("Text");
                }
            }
        }
        public Brush BackgroundColor
        {
            get
            {
                return this.BackgroundColorValue;
            }
            set
            {
                if (value != this.BackgroundColorValue)
                {
                    this.BackgroundColorValue = value;
                    NotifyPropertyChanged("BackgroundColor");
                }
            }
        }
       
    }
