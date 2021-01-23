     public I2CModel SelectedI2CDeviceList
            {
                get { return _selectedI2CDeviceList; }
                set
                {
                    _selectedI2CDeviceList = value;
                    AddressMessage = _selectedI2CDeviceList.I2CDeviceAddress;
                    NotifyPropertyChanged("SelectedI2CDevSize");
                }
            }
