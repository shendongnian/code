    public int SelectedBusRateItem
        {
            get { return _selectedBusRate; }
            set
            {
                _selectedBusRate = value;
                 ReadBusAndBaudRate();
                NotifyPropertyChanged("SelectedBusRateItem");
            }
        }
        private int _selectedBaudRate;
        public int SelectedBaudRateItem
        {
            get { return _selectedBaudRate; }
            set
            {
                _selectedBaudRate = value;
                ReadBusAndBaudRate();
                NotifyPropertyChanged("SelectedBaudRateItem");
            }
        }
        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                NotifyPropertyChanged("Speed");
            }
        }
        private void ReadBusAndBaudRate()
        {
            //Do some code
            Speed = 10; // will be your logical value.
            //For message notifications use MVVM frameworks such as cinch by Sacha Barber
        }
